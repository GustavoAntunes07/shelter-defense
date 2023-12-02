using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    public float force = 2f;
    public float stopDelay = 2f;
    float timer;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Mathf.Sign(Random.Range(-1, 1)), 1) * force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= stopDelay)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
