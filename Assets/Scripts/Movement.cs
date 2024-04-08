using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration = 10f;
    public float jumpForce = 16f;
    public float castDistance;

    public bool _isMovingRight;

    protected bool _isGrounded = false;
    protected bool _isJumping = false;
    protected bool _jumpInputHeld = false;

    public Vector2 boxSize;
    public LayerMask groundLayer;
    protected Vector2 _inputDirection;

    protected Rigidbody2D _rigidbody2d;
    protected Collider2D _collider2d;
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _collider2d = GetComponent<Collider2D>();
    }

    void Update()
    {
        HandleInput();
        HandleVertical();
    }

    void FixedUpdate()
    {
        CheckGround();
        HandleHorizontal();
        HorizontalMovement();
        Flip();
    }

    protected virtual void HandleInput()
    {

    }
    protected virtual void HandleVertical()
    {

    }

    protected virtual void HandleHorizontal()
    {

    }

    protected void HorizontalMovement()
    {
        _rigidbody2d.velocity = new Vector2(_inputDirection.x * acceleration, _rigidbody2d.velocity.y);
    }

    protected void VerticalMovement()
    {
        if (_jumpInputHeld == true)
        {
            Debug.Log("Should jump");
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpForce);
        }
        if (_jumpInputHeld == false)
        {
            //Debug.Log("Should Fall");
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _rigidbody2d.velocity.y * 0.3f);
        }
        
    }

    void CheckGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            _isGrounded = true;
            //Debug.Log($"Grounded: {_isGrounded}");
        }
        else
        {       
            _isGrounded = false;
            //Debug.Log($"Grounded: {_isGrounded}");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    void Flip()
    {
        if (_inputDirection.x == 0)
            return;

        if (_inputDirection.x > 0)
        {
            _isMovingRight = true;
        }

        if (_inputDirection.x < 0)
        {
            _isMovingRight = false;
        }
    }
}
