using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public bool _isFacingRight = true;

    private Vector3 _currentScale = Vector3.one;

    private Movement _movement;

    void Start()
    {
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

        if (_movement._isMovingRight == true && !_isFacingRight)
        {
            FlipCheck();
        }
        if (_movement._isMovingRight == false && _isFacingRight)
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
    }
}
