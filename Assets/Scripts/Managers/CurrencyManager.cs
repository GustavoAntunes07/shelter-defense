using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int profitMulti;
    public IntEvent OnSendCoins;
    public StringEvent OnSendCoinsText;
    private void Start()
    {
        OnSendCoinsText?.Invoke(coins.ToString());
    }

    public int GetCoins() => coins;

    public string SetCoins(int c)
    {
        if (c >= 0 && coins != c)
        {
            coins = c;
            OnSendCoins?.Invoke(coins);
            OnSendCoinsText?.Invoke(coins.ToString());
            return "success";
        }
        return "fail";
    }

    public string SpendCoins(int cost) => SetCoins(coins - cost);
    public string EarnCoins(int gain) => SetCoins(coins + (gain * profitMulti));
    public void SetProfitMulti(float m)
    {
        profitMulti = Mathf.FloorToInt(m);
    }
}
