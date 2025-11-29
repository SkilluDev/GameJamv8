using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GunManager gun;
    public void ShootGun()
    {
        Debug.Log("shoot");
        gun.Shoot();
    }
}
