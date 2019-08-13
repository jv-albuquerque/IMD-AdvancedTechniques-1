using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunMagazine : MonoBehaviour
{
    private int currentAmmo = 10;
    [SerializeField] private GameObject projectileType;

    private void Start()
    {
        UpdateAmmoCount.instance.setAmmoCount(currentAmmo);
    }

    public int CurrentAmmo
    {
        get => currentAmmo;
    }

    public void Shot()
    {
        currentAmmo -= 1;
        UpdateAmmoCount.instance.setAmmoCount(currentAmmo);
    }

    public GameObject ProjectileType { get => projectileType; set => projectileType = value; }
}
