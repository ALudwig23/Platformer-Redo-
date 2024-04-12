using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    protected Health _health;
    protected GameManager _gameManager;
    private void Start()
    {
        _health = FindObjectOfType<Health>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _health.Die();
            _gameManager.CurrentLevel = -1;
            _gameManager.ToNextLevel();
        }
    }
}
