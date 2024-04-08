using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    public Transform Target;
    public EnemyBoundary _enemyBoundary;
    public EnemyBoundary _enemyBoundary2;

    protected bool _playerSpotted = false;
    protected bool _flipDirection = false;

    protected override void HandleHorizontal()
    {
        
        if (_playerSpotted == true)
        {
            if (_enemyBoundary == null)
                return;

            if (Target == null)
            {
                Target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            if (Target == null)
                return;

            Vector2 TargetDirection = Target.position - transform.position;
            TargetDirection = TargetDirection.normalized;

            _inputDirection = TargetDirection;
        }

        if (_playerSpotted == false)
        {
            if (_inputDirection.x == 0)
            {
                _inputDirection = Vector2.right;
            }
            if (_enemyBoundary.EnemyCheck == true || _enemyBoundary2.EnemyCheck == true)
            {
                _flipDirection = !_flipDirection;

                if (_flipDirection)
                {
                    //Debug.Log("Moving Left");
                    _inputDirection = Vector2.left;
                }
                if (!_flipDirection)
                {
                    //Debug.Log("Moving Right");
                    _inputDirection = Vector2.right;
                }
            }

            
        }
        
    }
}
