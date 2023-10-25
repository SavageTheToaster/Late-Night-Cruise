using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVertical : MonoBehaviour
{
    public float maxRotationSpeed = 100.0f;
    public float maxRotationAngle = 20.0f;
    public float verticalSpeed = 5.0f;
    public float rotationReturnSpeed = 100.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 verticalVelocity = new Vector2(0f, verticalInput * verticalSpeed);

        rb.velocity = new Vector2(rb.velocity.x, verticalVelocity.y);

        float targetRotationSpeed = verticalInput * maxRotationSpeed;

        float currentRotation = rb.rotation;

        if (verticalInput != 0)
        {
            float targetRotation = currentRotation + targetRotationSpeed * Time.fixedDeltaTime;
            rb.rotation = Mathf.Clamp(targetRotation, -maxRotationAngle, maxRotationAngle);
        }
        else
        {
            rb.rotation = Mathf.MoveTowards(currentRotation, 0f, rotationReturnSpeed * Time.fixedDeltaTime);
        }
    }
}