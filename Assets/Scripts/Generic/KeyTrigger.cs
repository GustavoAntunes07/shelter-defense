using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class KeyTrigger : MonoBehaviour
{
    public Key key = Key.E;
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

    private void Update()
    {
        if (Keyboard.current[key].wasPressedThisFrame)
            OnPressed?.Invoke();

        if (Keyboard.current[key].wasReleasedThisFrame) OnReleased?.Invoke();
    }
}
