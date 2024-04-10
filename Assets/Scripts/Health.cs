using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HitEvent(GameObject source);
    public delegate void ResetEvent();

    public HitEvent OnHit;
    public ResetEvent OnHitReset;
    public Cooldown Invulnerability;

    public float Maxhealth = 10f;

    private float _currenthealth = 10f;
    private bool _canDamage = true;

    public float CurrentHealth {  get { return _currenthealth; } }

    void Start()
    {
        ResetHealthToMax();
    }

    void Update()
    {
        ResetInvulnerable();
    }

    void ResetInvulnerable()
    {
        if (_canDamage)
            return;

        if (Invulnerability.IsOnCooldown && _canDamage == false)
            return;

        _canDamage = true;

    }

    public void Damage(float damage, GameObject source)
    {
        if (!_canDamage)
            return;

        _currenthealth -= damage;

        if ( _currenthealth <= 0f)
        {
            Die();
        }

        Invulnerability.StartCooldown();
        _canDamage = false;

        OnHit?.Invoke(source);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    void ResetHealthToMax()
    {
        _currenthealth = Maxhealth;
    }
}