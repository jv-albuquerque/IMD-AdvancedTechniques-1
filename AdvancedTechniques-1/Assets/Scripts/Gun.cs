using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Gun that is equiped
    private enum GunEquiped
    {
        Shotgun = 1,
        M4 = 2,
        Ak47 = 3,
        M9 = 4
    }

    [SerializeField] private GunEquiped gunType = GunEquiped.M9;

    private GunType currentGun;

    [SerializeField] private GameObject projectile = null; //projectile that will be shiot
    [SerializeField] private Transform gunTip = null; // the tip of the gun
    [SerializeField] private float backspinDrag = 0.02f; // The force that simulate the spin of the projectile

    private GunMagazine magazine;

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

        magazine = GetComponent<GunMagazine>();
    }

    public void Shoot()
    {
        if(!delaying && magazine.CurrentAmmo > 0)
        {
            delaying = true;
            Invoke("DelayedShoot", delayToShoot);
        }
    }

    private void DelayedShoot()
    {
        delaying = false;
        magazine.Shot();
        currentGun.Shoot(magazine.ProjectileType, gameObject.transform);
    }

    public GameObject SetProjectile
    {
        set
        {
            projectile = value;
        }
    }
}
