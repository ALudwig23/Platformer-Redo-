using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddCameraMovement : MonoBehaviour
{
    public Camera Camera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Camera.GetComponent("CameraMovement") == null)
            {
                Camera.AddComponent<CameraMovement>();
                Destroy(gameObject);
            }
        }
    }
}
