using UnityEngine;

public class GetMagazine : MonoBehaviour
{
    [SerializeField] private Gun gun;

    public void ChangeMagazine(int nBullet, GameObject projectile)
    {
        gun.SetMagazine(nBullet, projectile);
    }

    public bool VerifyCompatibility(int type)
    {
        if (type == gun.GetType)
            return true;
        return false;
    }
}
