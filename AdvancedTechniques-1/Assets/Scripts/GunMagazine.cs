using UnityEngine;

public class GunMagazine : MonoBehaviour
{
    private int currentAmmo = 10;
    [SerializeField] private GameObject projectileType;

    private void Start()
    {
        if(UpdateAmmoCount.instance)
            UpdateAmmoCount.instance.SetAmmo(currentAmmo);
    }

    public int CurrentAmmo
    {
        get => currentAmmo;
    }

    public void Shot()
    {
        currentAmmo -= 1;
        if (UpdateAmmoCount.instance)
            UpdateAmmoCount.instance.SetAmmo(currentAmmo);
    }

    public GameObject ProjectileType { get => projectileType; set => projectileType = value; }
}
