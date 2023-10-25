using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHoriozntal : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float acceleration = 1.0f;
    public float horizontalDeceleration = 1.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 horizontalAccelerationVector = new Vector2(horizontalInput * acceleration, 0f);

        rb.velocity += horizontalAccelerationVector * Time.fixedDeltaTime;

        if (horizontalInput == 0)
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(Mathf.Max(rb.velocity.x - horizontalDeceleration * Time.fixedDeltaTime, 0), rb.velocity.y);
            }
            else if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(Mathf.Min(rb.velocity.x + horizontalDeceleration * Time.fixedDeltaTime, 0), rb.velocity.y);
            }
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0, maxSpeed), rb.velocity.y);
    }
}