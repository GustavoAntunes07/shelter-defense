using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAccelerationBasic = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAccelerationWhenStopping = 25f;
    [SerializeField, Range(0f, 100f)] private float maxAccelerationWhenTurning = 50f;

    [SerializeField, Tooltip(@"Se a velocidade for maior que isso 
    ou menor que isso negativo,
    ele está se movendo para
    o sistema de animação")] float velAnimationDeadzone = 0.4f;

    [Space(8), Header("Events"), Space(8)]
    public BoolEvent OnMove;

    private Vector2 direction, desiredVelocity, velocity;
    private Rigidbody2D rb;

    private float maxSpeedChange, acceleration;
    float _maxSpeed, _maxAccelerationBasic, _maxAccelerationWhenStopping, _maxAccelerationWhenTurning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        SetSpeedMultiplier(1f);
    }

    private void FixedUpdate()
    {
        velocity = rb.velocity;
        desiredVelocity = new Vector2(direction.x, 0f) * _maxSpeed;

        if (Mathf.Abs(direction.x) < .01f)
            acceleration = _maxAccelerationWhenStopping;
        else if (Mathf.Sign(direction.x) != Mathf.Sign(velocity.x))
            acceleration = _maxAccelerationWhenTurning;
        else
            acceleration = _maxAccelerationBasic;

        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        rb.velocity = velocity;
        OnMove?.Invoke(rb.velocity.x > velAnimationDeadzone || rb.velocity.x < -velAnimationDeadzone);
    }

    public void SetDirection(float d)
    {
        if (direction.x != d)
        {
            direction.x = d;
        }

        // if (Mathf.Sign(direction.x) != Mathf.Sign(d))
    }

    public void SetSpeedMultiplier(float multi)
    {
        _maxSpeed = maxSpeed * multi;
        _maxAccelerationBasic = maxAccelerationBasic * multi;
        _maxAccelerationWhenStopping = maxAccelerationWhenStopping * multi;
        _maxAccelerationWhenTurning = maxAccelerationWhenTurning * multi;
    }
}