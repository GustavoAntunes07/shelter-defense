using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public bool startOnAwake = false;
    public float startTime = 10f;
    public WaveSO[] waves;
    public Transform[] spawnPositions;
    List<HealthSystem> spawnedEnemies = new List<HealthSystem>();
    public float intermissionTime = 20f;
    public float shootTime = 3f;
    public UnityEvent OnWin;
    public StringEvent OnIntermissionTimerChange;
    public BoolEvent OnCanShoot;

    int wave = -1;
    float intermissionTimer;
    float shootTimer;

    public void NextWave() => SetWave(wave + 1);
    public void Reset() => SetWave(0);
    public string GetTimerText() => intermissionTimer >= 0 ? intermissionTimer.ToString("F0") : $"WAVE\n{wave + 1}";

    void Start()
    {
        if (startOnAwake)
            Reset();
        else
        {
            intermissionTimer = startTime;
            shootTimer = float.MaxValue;
        }
    }

    void Update()
    {
        var lastTimer = intermissionTimer;
        intermissionTimer -= Time.deltaTime;
        OnIntermissionTimerChange?.Invoke(GetTimerText());

        if (intermissionTimer <= 0 && lastTimer > 0)
        {
            if (wave >= 0)
                NextWave();
            else Reset();

            shootTimer = shootTime;
        }

        shootTimer -= Time.deltaTime;
        OnCanShoot?.Invoke(shootTimer <= 0 && intermissionTimer <= 0);
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
                        if (spawnedEnemies.Count <= 0 && wave != waves.Length - 1)
                            intermissionTimer = intermissionTime;
                        else if (wave == waves.Length - 1)
                            OnWin?.Invoke();
                    });
                }
            }
        }
    }
}