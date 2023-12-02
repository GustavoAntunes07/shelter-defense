using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public CoinDropSO drop;

    public void Trigger()
    {
        foreach (var coins in drop.coins)
        {
            for (int i = 0; i < coins.amount; i++)
            {
                Instantiate(coins.coin, transform.position, Quaternion.identity);
            }
        }
    }
}
