using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private RandomSound deathSound;
    [SerializeField] private AudioSource audioSource;

    public UnityEvent onPlayerDamage;

    private void Awake()
    {
        _currentHealth = maxHealth;
        
        if (healthBar != null)
            healthBar.SetHealth(1f);
        else
            Debug.LogWarning("PlayerHealth: HealthBar is not assigned!");
    }

    public bool hasTakenDamage { get; set; }

    public void Damage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, maxHealth);

        if (healthBar is not null)
            healthBar.SetHealth(_currentHealth / maxHealth);
        hasTakenDamage = true;

        onPlayerDamage.Invoke();

        if (_currentHealth <= 0f)
        {
            deathSound.Play(audioSource);
            Die();
        }
    }

    public void Die()
    {
        GameManager.Instance.GameOverByDeath();
    }
}