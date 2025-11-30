using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{
    [SerializeField] Image gunSprite;
    [SerializeField] Sprite gunShoot;
    [SerializeField] Sprite gunNormal;

    [SerializeField] float shootTime;

    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private Transform cameraPosition;

    [SerializeField] private float gunDamage;
    [SerializeField] private RandomSound gunShotSound;
    [SerializeField] private AudioSource audioSource;

    private Coroutine currentShoot;

    private bool shooting;

    public void Shoot()
    {
        if (!shooting)
        {
            currentShoot = StartCoroutine(ShootAnimation());
        }
    }

    IEnumerator ShootAnimation()
    {
        shooting = true;
        gunSprite.sprite = gunShoot;
        ShootGun();
        gunShotSound.Play(audioSource);
        
        yield return new WaitForSeconds(shootTime);
        gunSprite.sprite = gunNormal;
        shooting = false;
    }
    
    public void ShootGun()
    {
        RaycastHit hit;
        Debug.Log("test");

        if(Physics.Raycast(cameraPosition.position, cameraPosition.TransformDirection(Vector3.forward),  out hit, 100f))
        {
            Debug.DrawRay(cameraPosition.position, cameraPosition.TransformDirection(Vector3.forward) * hit.distance, Color.red, 20f);
            Debug.Log("hittt" + hit.distance+"layer"+hit.transform.gameObject.layer);
            if((enemyLayer & (1 << hit.transform.gameObject.layer)) != 0)
            {
                Debug.Log("enemy");
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                enemy.Damage(gunDamage, hit.transform, hit.point);
            }
        }
    }
}
