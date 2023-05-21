using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    [SerializeField, Range(-10, 10)] float checkOffset = -.5f;
    [SerializeField, Range(0, 10)] float checkRadius = .4f;
    [SerializeField] LayerMask checkMask = ~0;

    [Space(16)]
    public BoolEvent OnGroundedStateChanged;

    bool wasGrounded;

    void Start() {
        wasGrounded = IsGrounded();
        OnGroundedStateChanged?.Invoke(wasGrounded);
    }

    void Update() {
        if (wasGrounded != IsGrounded()) {
            wasGrounded = IsGrounded();
            OnGroundedStateChanged?.Invoke(wasGrounded);
        }

    }

    public bool IsGrounded() {
        Vector2 pos = new(transform.position.x, transform.position.y + checkOffset);
        return Physics2D.OverlapCircle(pos, checkRadius, checkMask);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        Vector2 pos = new(transform.position.x, transform.position.y + checkOffset);
        Gizmos.DrawWireSphere(pos, checkRadius);
    }
}
