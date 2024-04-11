using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void HandleInput()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    protected override void HandleVertical()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded || Input.GetButtonDown("Jump") && CoyoteTime.CurrentProgress == Cooldown.Progress.InProgress)
        {
            //Debug.Log("Jump held");
            _jumpInputHeld = true;
            VerticalMovement();
        }
        if (Input.GetButtonUp("Jump") && _rigidbody2d.velocity.y > 0f)
        {
            //Debug.Log("Jump not held");
            _jumpInputHeld = false;
            VerticalMovement();
        }

        if (_rigidbody2d.velocity.y > 0f && !_isGrounded)
        {
            _isJumping = true;
            _isFalling = false;
            _canCoyoteJump = false;
        }

        if (_rigidbody2d.velocity.y < 0f && !_isGrounded)
        {
            _isFalling = true;
            if (!_isJumping)
            {
                _canCoyoteJump = true;
            }
        }
    }
}

