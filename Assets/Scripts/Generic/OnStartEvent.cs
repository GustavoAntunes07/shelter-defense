using UnityEngine;
using UnityEngine.Events;

class OnStartEvent : MonoBehaviour
{
    public UnityEvent OnStart;

    void Start()
    {
        OnStart?.Invoke();
    }
}