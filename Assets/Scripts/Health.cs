using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;

    

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public bool hasTakenDamage { get; set; }
    public void Die()
    {
        Destroy(gameObject);
    }
}
