using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVertical : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float maxRotationAngle = 45f;
    public float returnToZeroSpeed = 5f;

    private void Update()
    {
        // Get vertical input
        float verticalInput = Input.GetAxis("Vertical");

        // Move the object up and down based on vertical input
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);

        // Rotate the object based on vertical input
        float rotationAmount = verticalInput * rotationSpeed * Time.deltaTime;
        float newRotation = transform.rotation.eulerAngles.z + rotationAmount;

        // Ensure the rotation stays within the specified range
        if (newRotation > 180f) newRotation -= 360f;
        newRotation = Mathf.Clamp(newRotation, -maxRotationAngle, maxRotationAngle);

        transform.rotation = Quaternion.Euler(0, 0, newRotation);

        // If there is no input, smoothly return to the normal rotation (zero rotation)
        if (Mathf.Approximately(verticalInput, 0f))
        {
            float lerpedRotation = Mathf.LerpAngle(transform.rotation.eulerAngles.z, 0f, returnToZeroSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, lerpedRotation);
        }

        // Stop moving when the rotation is close to zero
        if (Mathf.Approximately(transform.rotation.eulerAngles.z, 0f))
        {
            // Stop moving the object
            transform.Translate(Vector3.zero);
        }
    }
}