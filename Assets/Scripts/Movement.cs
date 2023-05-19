using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {
    [SerializeField] float speed = 5; // meters per second
    [SerializeField] float jumpForce = 5;
    [SerializeField] float groundCheckOffset = -.5f;
    [SerializeField] float groundCheckRadius = .5f;
    [SerializeField] LayerMask groundCheckMask = ~0;

    bool jumpRequest;
    float dir;
    Rigidbody2D rb;

    public void SetDirection(float d) => dir = d;
    public void Jump() => jumpRequest = true;
    public bool IsGrounded() {
        return Physics2D.OverlapCircle(
                rb.position + new Vector2(0, groundCheckOffset),
                groundCheckRadius,
                groundCheckMask
            );
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        HandleInput();
        HandleMovement();
        HandleJump();
    }

    // Input apenas para testar
    void HandleInput() {
        dir = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void HandleMovement() {
        var movement = dir * speed;
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    void HandleJump() {
        if (jumpRequest && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequest = false;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, groundCheckOffset, 0), groundCheckRadius);
    }
}
