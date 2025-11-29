using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public bool hasTakenDamage { get; set; }
    public void Die()
    {
        throw new System.NotImplementedException();
    }
}
