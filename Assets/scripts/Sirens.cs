using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sirens : MonoBehaviour
{
    public float startXPosition = 0f;
    public float endXPosition = 10f;
    public float teleportInterval = 2.0f;

    private bool isAtStart = true;
    private float nextTeleportTime;

    private void Start()
    {
        Vector3 initialPosition = transform.position;
        initialPosition.x = startXPosition;
        transform.position = initialPosition;

        nextTeleportTime = Time.time + teleportInterval;
    }

    private void Update()
    {
        if (Time.time >= nextTeleportTime)
        {
            TeleportToOtherPosition();
            nextTeleportTime = Time.time + teleportInterval;
        }
    }

    private void TeleportToOtherPosition()
    {
        if (isAtStart)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = endXPosition;
            transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = transform.position;
            newPosition.x = startXPosition;
            transform.position = newPosition;
        }

        isAtStart = !isAtStart;
    }
}