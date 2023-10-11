using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Header("Properties"), Space(8)]

    [SerializeField] float damage = 15f;
    [Tooltip("If gravity is enabled, this will become an impulse, not a velocity.")]
    [SerializeField] float speed = 15f;
    [SerializeField] bool gravityEnabled = false;

    [SerializeField] LayerMask mask;

    [Header("Events"), Space(8)]
    public UnityEvent onHitObject;

    Rigidbody2D rb;
    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityEnabled ? rb.gravityScale : 0f;
    }

    void FixedUpdate()
    {
        rb.velocity = gravityEnabled ? rb.velocity : dir * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        this.dir = dir;

        if (gravityEnabled)
        {
            rb.AddForce(dir * speed, ForceMode2D.Impulse);
        }
    }

    public void SetLayerMask(LayerMask newMask) => mask = newMask;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameUtils.IsOnLayerMask(other.gameObject.layer, mask))
        {
            if (other.TryGetComponent(out HealthSystem hp))
            {
                hp.RemoveHp(damage);
                onHitObject?.Invoke();
            }
        }
    }
}