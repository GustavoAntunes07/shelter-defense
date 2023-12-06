using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class KrampusAI : MonoBehaviour
{
    public WaveSO horde;
    public float spawnDelay = 10f;
    public float spawnOffset = 5f;
    public BoolEvent OnSendShootState;

    List<HealthSystem> spawnedEnemies = new List<HealthSystem>();
    HealthSystem myHp;
    Rigidbody2D rb;
    CapsuleCollider2D col;
    float timer;

    private void Start()
    {
        myHp = GetComponent<HealthSystem>();
        timer = spawnDelay;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();

        OnSendShootState?.AddListener((bool b) =>
        {
            rb.constraints = b ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.FreezeAll;
            col.enabled = b;
        });
    }

    private void Update()
    {
        var lastTimer = timer;
        timer -= Time.deltaTime;

        if (timer <= 0 && lastTimer > 0)
        {
            SpawnHorde();
        }
        OnSendShootState?.Invoke(spawnedEnemies.Count == 0);
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
                    if (spawnedEnemies.Count == 0)
                    {
                        timer = spawnDelay;
                    }
                });
            }
        }
    }
}
