using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public WaveSO[] waves;
    public Transform[] spawnPositions;
    List<HealthSystem> spawnedEnemies = new List<HealthSystem>();
    public float intermissionTime = 5;
    public int frameDelayEventTrigger = 4;
    public StringEvent OnIntermissionTimerChange;

    int wave = 0;
    float intermissionTimer;
    int frameDelay;

    public void NextWave() => SetWave(wave + 1);
    public void Reset() => SetWave(0);
    public string GetTimer() => intermissionTimer >= 0 ? intermissionTimer.ToString("F0") : "";

    void Start()
    {
        Reset();
    }

    void Update()
    {
        var lastTimer = intermissionTimer;
        intermissionTimer -= Time.deltaTime;
        if (frameDelay > 0) frameDelay--;
        else if (frameDelay <= 0)
        {
            OnIntermissionTimerChange?.Invoke(GetTimer());
            frameDelay = frameDelayEventTrigger;
        }

        if (intermissionTimer <= 0 && lastTimer > 0)
        {
            NextWave();
        }
    }

    public void SetWave(int i)
    {
        if (i >= 0 && i < waves.Length)
        {
            wave = i;

            foreach (var waveEnemy in waves[wave].uniqueEnemies)
            {
                for (int x = 0; x < waveEnemy.count; x++)
                {
                    var position = spawnPositions[x % spawnPositions.Length].position;
                    var hp = Instantiate(waveEnemy.obj, position, Quaternion.identity);
                    spawnedEnemies.Add(hp);
                    hp.OnHpEmpty?.AddListener(() =>
                    {
                        spawnedEnemies.Remove(hp);
                        if (spawnedEnemies.Count <= 0)
                        {
                            intermissionTimer = intermissionTime;
                        }
                        return;
                    });
                }
            }
        }
    }
}