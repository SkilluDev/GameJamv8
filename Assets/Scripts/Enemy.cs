using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private EnemyHealth health;

    [SerializeField] private RandomSound hitSound;

    [SerializeField] private AudioSource audioSource;
   
    public void SpawnExplosion(Transform explosionTransform, Vector3 hitPoint)
    {
        Debug.DrawRay(explosionTransform.position, Vector3.up*10f, Color.red, 10f);
        var explosion = Instantiate(explosionPrefab, hitPoint, explosionTransform.rotation);
        
        Destroy(explosion, 1f);
    }

    public void Damage(float damage, Transform hitTransform, Vector3 hitPoint)
    {
        health.Damage(damage);
        SpawnExplosion(hitTransform, hitPoint);
        hitSound.Play(audioSource);
    }
}
