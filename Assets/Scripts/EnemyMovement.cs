using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    public Transform Target;
    public EnemyVision _enemyVision;
    public EnemyBoundary _enemyBoundary;
    public EnemyBoundary _enemyBoundary2;

    protected override void HandleHorizontal()
    {
        
        if (_enemyVision._playerFound == true)
        {
            if (Target == null)
            {
                Target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            if (Target == null)
                return;

            if (_isMovingRight == true && Target.position.x > transform.position.x || _isMovingRight == false && Target.position.x < transform.position.x)
            {
                acceleration = 7f;

                Vector2 TargetDirection = Target.position - transform.position;
                TargetDirection = TargetDirection.normalized;

                _inputDirection = TargetDirection;
            }
            else
            {
                acceleration = 3f;
            }

        }
        if (_enemyVision._playerFound == false)
        {
            acceleration = 3f;
        }

        //Debug.Log(_inputDirection.x);
        if (_inputDirection.x == 0)
        {
            _inputDirection.x = 1;
        }
        if (_inputDirection.x > 0 && _inputDirection.x < 1)
        {
            _inputDirection.x = 1;
        }
        if (_inputDirection.x < 0 && _inputDirection.x > -1)
        {
            _inputDirection.x = -1;
        }

        if (_enemyBoundary == null)
            return;

        if (_enemyBoundary.EnemyCheck == true || _enemyBoundary2.EnemyCheck == true)
        {
            _inputDirection.x *= -1f;
        }

    }
}
