using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] int coins;
    public IntEvent OnSendCoins;
    public StringEvent OnSendCoinsText;
    private void Start()
    {
        OnSendCoinsText?.Invoke(coins.ToString());
    }

    public int GetCoins() => coins;

    public void SetCoins(int c)
    {
        if (c >= 0 && coins != c)
        {
            coins = c;
            OnSendCoins?.Invoke(coins);
            OnSendCoinsText?.Invoke(coins.ToString());
        }
    }

    public void SpendCoins(int cost) => SetCoins(coins - cost);
    public void EarnCoins(int gain) => SetCoins(coins + gain);

    [ContextMenu("Add 100 coins")]
    public void Add100() => EarnCoins(100);
    [ContextMenu("Remove 100 coins")]
    public void Remove100() => SpendCoins(100);
}
