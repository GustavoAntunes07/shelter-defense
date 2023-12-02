using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] float maxJumpHeight = 2.25f;
    [SerializeField, Range(0f, 10f)] float minJumpHeight = 1.15f;
    [SerializeField, Range(0f, 5f)] float fallingGravityMultiplier = 2f;
    [SerializeField, Range(0f, 5f)] float risingGravityMultiplier = 1f;
    [SerializeField, Range(0f, 1f)] float coyoteTime = 0.25f;
    [SerializeField, Range(0f, 1f)] float jumpBufferingTime = 0.2f;

    public BoolEvent onGrounded;
    public UnityEvent onCalculationsMade;

    Rigidbody2D rb;
    Vector2 velocity;

    float minJumpSpeed, maxJumpSpeed;
    bool jumpHold, wasHoldingJump, isGrounded;
    float coyoteTimeTimer;
    float jumpBufferingTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        minJumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * risingGravityMultiplier * minJumpHeight);
        maxJumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * risingGravityMultiplier * maxJumpHeight);
    }

    private void FixedUpdate()
    {
        velocity = rb.velocity;

        HandleJump();

        rb.velocity = velocity;
    }

    private void HandleJump()
    {
        coyoteTimeTimer -= Time.deltaTime;
        if (isGrounded)
        {
            coyoteTimeTimer = coyoteTime;
        }

        jumpBufferingTimer -= Time.deltaTime;
        if (jumpHold != wasHoldingJump)
        {
            wasHoldingJump = jumpHold;
            jumpBufferingTimer = jumpBufferingTime;
        }

        if (rb.velocity.y > 0)
            rb.gravityScale = risingGravityMultiplier;
        else if (rb.velocity.y < 0)
            rb.gravityScale = fallingGravityMultiplier;

        if (coyoteTimeTimer > 0 && jumpBufferingTimer > 0)
        {
            coyoteTimeTimer = 0;
            jumpBufferingTimer = 0;

            if (velocity.y <= minJumpSpeed)
                velocity.y = maxJumpSpeed;

            else
            {
                velocity.y = minJumpSpeed;
            }

        }
        onCalculationsMade?.Invoke();
    }

    public void SetGroundedState(bool g)
    {
        if (isGrounded != g)
        {
            isGrounded = g;
            onGrounded?.Invoke(isGrounded);
        }
    }
    public void SetJumpState(bool j) => jumpHold = j;
}