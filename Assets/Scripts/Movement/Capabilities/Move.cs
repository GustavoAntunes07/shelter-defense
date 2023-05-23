using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour {
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAccelerationBasic = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAccelerationWhenStopping = 25f;
    [SerializeField, Range(0f, 100f)] private float maxAccelerationWhenTurning = 50f;

    public BoolEvent OnMove;

    private Vector2 direction, desiredVelocity, velocity;
    private Rigidbody2D rb;

    private float maxSpeedChange, acceleration;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        velocity = rb.velocity;
        desiredVelocity = new Vector2(direction.x, 0f) * maxSpeed;

        if (Mathf.Abs(direction.x) < .01f)
            acceleration = maxAccelerationWhenStopping;
        else if (Mathf.Sign(direction.x) != Mathf.Sign(velocity.x))
            acceleration = maxAccelerationWhenTurning;
        else
            acceleration = maxAccelerationBasic;

        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        rb.velocity = velocity;
    }

    public void SetDirection(float d) {
        if (direction.x != d) {
            direction.x = d;
            OnMove?.Invoke(direction.x != 0);
        }
    }
}