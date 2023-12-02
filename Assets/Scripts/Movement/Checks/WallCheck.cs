using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallCheck : MonoBehaviour
{
    public LayerMask mask = ~0;
    public UnityEvent OnReachWall;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (GameUtils.IsOnLayerMask(other.gameObject.layer, mask))
        {
            OnReachWall?.Invoke();
        }
    }
}
