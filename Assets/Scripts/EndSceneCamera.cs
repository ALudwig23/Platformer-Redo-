using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndSceneCamera : MonoBehaviour
{
    public Camera Camera;
    public CameraMovement CameraMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(Camera.GetComponent<CameraMovement>());
            Camera.AddComponent<CameraMovementEnd>();
        }
    }
}
