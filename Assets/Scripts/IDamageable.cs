using UnityEngine;

public interface IDamageable
{
    public void Damage(float damage);

    public bool hasTakenDamage { get; set; }

    public void Die();
}
