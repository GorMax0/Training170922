using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
    }

    public void ApplyPlayerSpell(Vector3 force, Vector3 playerPositoin, int powerSpell)
    {
        _rigidbody.AddForceAtPosition(force, playerPositoin, ForceMode.VelocityChange);

        if (powerSpell > 0)
            Heal(powerSpell);
        else
            TakeDamage(-powerSpell);

        Debug.Log(_currentHealth);
    }

    private void Heal(int powerHeal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + powerHeal, _currentHealth, _maxHealth);
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}