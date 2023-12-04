using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaTrigger : MonoBehaviour
{
    public LayerMask mask = ~0;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameUtils.IsOnLayerMask(other.gameObject.layer, mask))
        {
            OnEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GameUtils.IsOnLayerMask(other.gameObject.layer, mask))
        {
            OnExit?.Invoke();
        }
    }
}
