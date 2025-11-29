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
        yield return new WaitForSeconds(shootTime);
        gunSprite.sprite = gunNormal;
        shooting = false;
    }
}
