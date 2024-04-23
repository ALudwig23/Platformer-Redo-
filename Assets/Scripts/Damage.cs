using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float DamageDealt;
    public GameObject Source;

    protected Health _health;
    
    private void Start()
    {
        _health = FindObjectOfType<Health>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _health.Damage(DamageDealt,Source); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _health.Damage(DamageDealt, Source);

        }
    }
}
