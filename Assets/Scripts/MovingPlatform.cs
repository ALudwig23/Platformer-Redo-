using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public PlayerMovement PlayerMovement;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerMovement == null)
                return;

            if (PlayerMovement.IsGrounded == true)
            {
                collision.collider.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerMovement == null)
                return;

            if (PlayerMovement.IsGrounded == false)
            {
                collision.collider.transform.SetParent(null);
            }
        }
    }
}
