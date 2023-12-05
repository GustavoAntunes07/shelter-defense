using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class KrampusAI : MonoBehaviour
{
    public WaveSO horde;
    public float spawnDelay = 10f;
    public float spawnOffset = 5f;
    public BoolEvent OnSendShootState;

    List<HealthSystem> spawnedEnemies = new List<HealthSystem>();
    HealthSystem myHp;
    float timer;

    private void Start()
    {
        myHp = GetComponent<HealthSystem>();
        myHp.OnHpEmpty?.AddListener(() =>
        {
            foreach (var e in spawnedEnemies)
            {
                spawnedEnemies.Remove(e);
                Destroy(e.gameObject);
            }
        });
        timer = spawnDelay;
    }

    private void Update()
    {
        var lastTimer = timer;
        timer -= Time.deltaTime;

        if (timer <= 0 && lastTimer > 0)
        {
            SpawnHorde();
        }
    }

    public void SpawnHorde()
    {
        foreach (var hordeEnemy in horde.uniqueEnemies)
        {
            for (int i = 0; i < hordeEnemy.count; i++)
            {
                var position = new Vector2(
                    Random.Range(transform.position.x - spawnOffset,
                        transform.position.x + spawnOffset),
                    transform.position.y
                );

                var hp = Instantiate(hordeEnemy.obj, (Vector3)position, Quaternion.identity);
                spawnedEnemies.Add(hp);
                hp.OnHpEmpty?.AddListener(() =>
                {
                    spawnedEnemies.Remove(hp);
                    OnSendShootState?.Invoke(spawnedEnemies.Count == 0);
                    if (spawnedEnemies.Count == 0)
                    {
                        timer = spawnDelay;
                    }
                });
            }
        }
        OnSendShootState?.Invoke(spawnedEnemies.Count == 0);
    }
}
