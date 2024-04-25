using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlock : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public GameObject Block;
    public Camera Camera;
    public Animator _animator;
    public Animator _animator2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerMovement != null)
            {
                Destroy(PlayerMovement);
            }

            if (Block != null)
            {
                Destroy(Block);
            }

            if (_animator != null)
            {
                _animator.SetBool("canUp", true);
            }

            if (_animator2 != null)
            {
                _animator2.SetBool("canSide", true);
            }
            
            if (Camera != null)
            {
                Destroy(Camera.GetComponent("CameraMovement"));
            }
        }
    }
}
