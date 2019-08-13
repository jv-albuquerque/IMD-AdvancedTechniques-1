﻿using System.Collections;
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

    [SerializeField] private Transform gunTip = null; // the tip of the gun
    [SerializeField] private float backspinDrag = 0.02f; // The force that simulate the spin of the projectile

    private GunMagazine magazine;

    private float delayToShoot = 0f;
    private bool delaying = false;

    private bool automatic = false; // if the gun shoot automatic
    private bool shooting = false; // if the gun is automatic, see if the player is holding the shoot button

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

        if (UpdateHopUpCount.instance)
            UpdateHopUpCount.instance.SetHopUp(backspinDrag);

        if (UpdateManualAutomatic.instance)
            UpdateManualAutomatic.instance.SetText(automatic);

        if (UpdateTypeOfGun.instance)
            UpdateTypeOfGun.instance.SetText(gunType.ToString());
    }

    public void Shoot()
    {
        shooting = true;
        if(!delaying && magazine.CurrentAmmo > 0)
        {
            delaying = true;
            Invoke("DelayedShoot", delayToShoot);
        }
    }

    public void SetAutomatic()
    {
        automatic = !automatic;
        if (UpdateManualAutomatic.instance)
            UpdateManualAutomatic.instance.SetText(automatic);
    }

    public void ReleaseTrigger()
    {
        if (automatic)
        {
            shooting = false;
            delaying = false;
            CancelInvoke();
        }
    }

    private void DelayedShoot()
    {
        delaying = false;
        magazine.Shot();
        currentGun.Shoot(magazine.ProjectileType, gameObject.transform);

        if(automatic && shooting)
        {
            Shoot();
        }
    }

    public float SetHopUp
    {
        set
        {
            backspinDrag += (value / 1000) * 2;

            backspinDrag = Mathf.Clamp(backspinDrag, 0.001f, 0.04f);

            currentGun.GetBackspinDrag = backspinDrag;

            if (UpdateHopUpCount.instance)
                UpdateHopUpCount.instance.SetHopUp(backspinDrag);
        }
    }

    public int GetGunType
    {
        get
        {
            switch (gunType)
            {
                case GunEquiped.Shotgun:
                    return 1;
                case GunEquiped.M4:
                    return 2;
                case GunEquiped.Ak47:
                    return 3;
                case GunEquiped.M9:
                    return 4;
                default:
                    return 0;
            }
        }
    }

    public void SetMagazine(int nBullet, GameObject projectile)
    {
        magazine.CurrentAmmo = nBullet;
        magazine.ProjectileType = projectile;
    }
}
