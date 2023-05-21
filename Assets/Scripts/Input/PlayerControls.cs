using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour, InputControls.IGameplayActions {
    public BoolEvent OnJumpEvent;

    [Space]
    public FloatEvent OnMoveEvent;

    InputControls i;

    void Start() {
        if (i == null)
            CreateInstance();
    }

    void CreateInstance() {
        i = new InputControls();
        i.Enable();
        i.Gameplay.SetCallbacks(this);
    }

    void OnEnable() {
        if (i != null)
            i.Enable();
        else
            CreateInstance();
    }

    void OnDisable() {
        if (i != null)
            i.Disable();
        else
            CreateInstance();
    }

    public void OnJump(InputAction.CallbackContext context) {
        OnJumpEvent?.Invoke(context.ReadValue<float>() > 0.1f);
    }

    public void OnMove(InputAction.CallbackContext context) {
        OnMoveEvent?.Invoke(context.ReadValue<float>());
    }
}