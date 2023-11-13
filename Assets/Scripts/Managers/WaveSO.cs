using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "SOs/Wave")]
public class WaveSO : ScriptableObject
{
    public WaveEnemy[] uniqueEnemies;
}

[System.Serializable]
public class WaveEnemy
{
    public HealthSystem obj;
    public int count;
}
