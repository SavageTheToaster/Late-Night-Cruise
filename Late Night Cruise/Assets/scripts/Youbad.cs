using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youbad : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            transform.position = Vector3.zero;

            Debug.Log("Game Over");
        }
    }
}