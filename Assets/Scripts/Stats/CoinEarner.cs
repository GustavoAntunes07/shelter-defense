using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoinEarner : MonoBehaviour
{
    public int amount = 1;
    public LayerMask mask = ~0;
    public UnityEvent OnCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameUtils.IsOnLayerMask(other.gameObject.layer, mask))
        {
            var currencyManager = FindObjectOfType(typeof(CurrencyManager));
            if (currencyManager != null)
            {
                currencyManager.GetComponent<CurrencyManager>().EarnCoins(amount);
            }
            OnCollected?.Invoke();
        }
    }

    public void DestroyYourself() => Destroy(gameObject);
}
