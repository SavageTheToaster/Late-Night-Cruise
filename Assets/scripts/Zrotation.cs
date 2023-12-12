using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zrotation : MonoBehaviour
{
    // Adjust this value to control the rotation speed
    public float rotationSpeed = 180.0f; // Degrees per second

    // Adjust this value to set the maximum rotation angle
    public float maxRotationAngle = 45.0f;

    // Adjust this value to control the smoothness of rotation back to 0
    public float rotationDamping = 2.0f;

    private bool reachedMaxAngle = false;

    void Update()
    {
        // Get vertical input
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate the object based on vertical input
        RotateObjectByInput(verticalInput);
    }

    void RotateObjectByInput(float input)
    {
        // Calculate the rotation angle based on input and rotation speed
        float rotationAngle = input * rotationSpeed * Time.deltaTime;

        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.Euler(0, 0, rotationAngle) * transform.rotation;

        // Convert the angles to be within the range of -180 to 180
        float currentRotation = Mathf.Repeat(transform.rotation.eulerAngles.z + 180, 360) - 180;

        // Check if the angle is close to the maximum and set a flag
        if (Mathf.Abs(currentRotation + rotationAngle) >= maxRotationAngle)
        {
            reachedMaxAngle = true;
        }

        // Apply damping to smoothly rotate back to 0 when there is no input
        if (input == 0.0f)
        {
            float step = rotationDamping * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), step);
            reachedMaxAngle = false; // Reset the flag when there is no input
        }
        else
        {
            // Calculate the clamped rotation angle to stay within the specified range
            float clampedRotationAngle = Mathf.Clamp(currentRotation + rotationAngle, -maxRotationAngle, maxRotationAngle);

            // If we have reached the max angle, don't apply additional rotation
            if (!reachedMaxAngle)
            {
                targetRotation = Quaternion.Euler(0, 0, clampedRotationAngle);
            }

            // Rotate the object around the Z-axis
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
    }
}