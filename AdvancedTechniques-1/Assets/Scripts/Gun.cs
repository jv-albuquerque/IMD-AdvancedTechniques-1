using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private enum GunEquiped
    {
        Shotgun = 1,
        M4 = 2,
        Ak47 = 3,
        M9 = 4
    }

    [SerializeField] private GunEquiped gunType = GunEquiped.M9;

    private GunType currentGun;

    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform gunTip = null;
    [SerializeField] private float backspinDrag = 0.02f;

    private float delayToShoot = 0f;
    private bool delaying = false;

    private void Awake()
    {
        switch (gunType)
        {
            case GunEquiped.Shotgun:
                currentGun = gameObject.AddComponent<Shotgun>();
                break;
            case GunEquiped.M4:
                currentGun = gameObject.AddComponent<M4>();
                break;
            case GunEquiped.Ak47:
                currentGun = gameObject.AddComponent<Ak47>();
                break;
            case GunEquiped.M9:
                currentGun = gameObject.AddComponent<M9>();
                break;
            default:
                break;
        }

        currentGun.GetGunTip = gunTip;
        currentGun.GetBackspinDrag = backspinDrag;
        delayToShoot = currentGun.GetDelayToShoot;
    }

    public void Shoot()
    {
        if(!delaying)
        {
            delaying = true;
            Invoke("DelayedShoot", delayToShoot);
        }
    }

    private void DelayedShoot()
    {
        delaying = false;
        currentGun.Shoot(projectile, gameObject.transform);
    }

    public GameObject SetProjectile
    {
        set
        {
            projectile = value;
        }
    }
}
