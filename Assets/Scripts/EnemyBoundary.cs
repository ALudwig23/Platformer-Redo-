using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundary : MonoBehaviour
{
    public bool EnemyCheck;

    protected Collider2D _collider2d;
    void Start()
    {
        _collider2d = GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyCheck = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyCheck = false;
        }
    }
}
