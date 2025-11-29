using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    [SerializeField] private RandomSound deathSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject PlayAndDie;
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
        Instantiate(PlayAndDie, this.transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
