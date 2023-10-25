using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlusionOfInfinity : MonoBehaviour
{
    public float teleportPositionX = 1.26f;
    public float teleportTriggerX = 956.0f;

    private void Update()
    {
 
        if (transform.position.x >= teleportTriggerX)
        {
            Vector3 newPosition = new Vector3(teleportPositionX, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}