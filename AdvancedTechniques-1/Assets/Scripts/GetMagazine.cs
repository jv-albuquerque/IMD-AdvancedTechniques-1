using UnityEngine;

public class GetMagazine : MonoBehaviour
{
    [SerializeField] private Gun gun = null;

    public void ChangeMagazine(int nBullet, GameObject projectile)
    {
        gun.SetMagazine(nBullet, projectile);
    }

    public bool VerifyCompatibility(int type)
    {
        if (type == gun.GetGunType)
            return true;
        return false;
    }
}
