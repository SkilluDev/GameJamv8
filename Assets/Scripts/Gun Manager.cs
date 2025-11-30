using System.Collections;
using Unity.Cinemachine;
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

    [SerializeField] private CinemachineImpulseSource cinemachineImpulseSource;

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
        ShakeCamera();
        yield return new WaitForSeconds(shootTime);
        gunSprite.sprite = gunNormal;
        shooting = false;
    }

    private void ShakeCamera()
    {
        bool right = Random.Range(0, 2) == 1 ? true : false;
        bool top = Random.Range(0, 2) == 1 ? true : false;
        Vector3 bounce = new Vector3(Random.Range(0.2f, 0.3f) * (right?1:-1),Random.Range(0.2f, 0.3f) * (top?1:-1), 0);
        cinemachineImpulseSource.GenerateImpulse(bounce);
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
