using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    [SerializeField] private RandomSound deathSound;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            deathSound.Play(audioSource);
            Die();
        }
    }

    public bool hasTakenDamage { get; set; }
    public void Die()
    {
        Destroy(gameObject);
    }
}
