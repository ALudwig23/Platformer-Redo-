using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public PlayerMovement _playerMovement;
    private Rigidbody2D _rigidbody2d;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerMovement.IsGrounded == true)
            {
                _animator.SetBool("playerOn", true);
            }
        }
    }
}
