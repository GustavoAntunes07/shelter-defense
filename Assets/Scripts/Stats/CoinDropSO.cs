using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinDrop", menuName = "SOs/CoinDrop")]
public class CoinDropSO : ScriptableObject
{
    public CoinDropItem[] coins;
}


[System.Serializable]
public class CoinDropItem
{
    public Coin coin;
    public int amount = 1;
}