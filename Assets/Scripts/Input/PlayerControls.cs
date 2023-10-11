using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour, InputControls.IGameplayActions {
    public BoolEvent onJumpEvent;
    public FloatEvent onMoveEvent;
    public BoolEvent onShootEvent;
    public Vector2Event onMouseDirection;

    InputControls i;
    Camera main;
    Vector2 pos;

    void Start() {
        main = Camera.main;

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
        onJumpEvent?.Invoke(context.ReadValue<float>() > 0.1f);
    }

    public void OnMove(InputAction.CallbackContext context) {
        onMoveEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnShoot(InputAction.CallbackContext context) {
        onShootEvent?.Invoke(context.ReadValue<float>() > 0.1f);
    }

    public void OnMousePosition(InputAction.CallbackContext context) {
        var rawPos = context.ReadValue<Vector2>();

        if (context.control.device is Mouse)
            pos = (Vector2)main.ScreenToWorldPoint(rawPos);

        if (context.control.device is Gamepad && rawPos != Vector2.zero) {
            pos = (Vector2)transform.position + rawPos;
        }

        var dir = (pos - (Vector2)transform.position).normalized;

        onMouseDirection?.Invoke(dir);
    }
}