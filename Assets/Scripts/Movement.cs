using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    bool jumpRequest;
    float dir;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        rb.velocity = new Vector2(actualSpeed, rb.velocity.y);
    }

    void HandleJump() {
        if (jumpRequest) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequest = false;
        }
    }


    public void SetDirection(float d) => dir = d;

    public void Jump() => jumpRequest = true;
}
