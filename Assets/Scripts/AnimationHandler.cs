using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public bool _isFacingRight;

    private Vector3 _currentScale = Vector3.one;

    private Animator _animator; 
    private Movement _movement;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = transform.parent.GetComponent<Movement>();

        _currentScale = transform.localScale; 
    }

    void Update()
    {
        HandleFlip();
        UpdateAnimator();
    }

    void HandleFlip()
    {
        if (_movement == null)
            return;

        if (_movement.IsMovingRight == true && !_isFacingRight)
        {
            FlipCheck();
        }
        if (_movement.IsMovingLeft == true && _isFacingRight)
        {
            FlipCheck();
        }
    }
    
    void FlipCheck()
    {
        _currentScale.x *= -1;
        transform.localScale = _currentScale;
        _isFacingRight = !_isFacingRight;
    }

    void UpdateAnimator()
    {
        if (_movement == null)
            return;
        
        _animator.SetBool("isRunning", _movement.IsRunning);
        _animator.SetBool("isJumping", _movement.IsJumping);
        _animator.SetBool("isFalling", _movement.IsFalling);
        _animator.SetBool("isGrounded", _movement.IsGrounded);
    }
}
