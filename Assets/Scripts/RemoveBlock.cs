using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlock : MonoBehaviour
{
    public GameObject Block;
    public Camera Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Block == null)
            return;

        if (collision.CompareTag("Player"))
        {
            Destroy(Block);
            Destroy(Camera.GetComponent("CameraMovement"));
        }
    }
}
