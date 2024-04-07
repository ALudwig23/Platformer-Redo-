using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void HandleVerticalInput()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            Debug.Log("Jump held");
            _jumpInputHeld = true;
            VerticalMovement();
        }
        if (Input.GetButtonUp("Jump") && _rigidbody2d.velocity.y > 0f)
        {
            Debug.Log("Jump not held");
            _jumpInputHeld = false;
            VerticalMovement();
        }
    }
}

