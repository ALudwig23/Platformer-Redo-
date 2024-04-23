using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody2d.velocity = new Vector2(1,0);
    }

}
