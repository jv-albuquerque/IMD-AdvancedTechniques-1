using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    private enum BulletType
    {
        Shotgun = 1,
        M4 = 2,
        Ak47 = 3,
        M9 = 4
    }


    [SerializeField] private MeshRenderer boxRender = null;
    [SerializeField] private GameObject projectile = null;

    [Header("Properties")]
    [SerializeField] private BulletType bulletType = BulletType.Shotgun;
    [SerializeField] private Material mShotgun;
    [SerializeField] private Material mM4;
    [SerializeField] private Material mAk47;
    [SerializeField] private Material mM9;

    private float[] bulletMass = { 0.00012f, 0.0002f, 0.00023f, 0.00025f, 0.00028f, 0.00030f, 0.00033f, 0.00038f, 0.00043f, 0.00045f };
    private int maxCapacity;
    private int type = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (projectile)
            projectile.GetComponent<BbsProperties>().Mass = bulletMass[Random.Range(0, bulletMass.Length -1)];

        switch (bulletType)
        {
            case BulletType.Shotgun:
                boxRender.material = mShotgun;
                maxCapacity = 12;
                type = 1;
                break;
            case BulletType.M4:
                boxRender.material = mM4;
                maxCapacity = 30;
                type = 2;
                break;
            case BulletType.Ak47:
                boxRender.material = mAk47;
                maxCapacity = 30;
                type = 3;
                break;
            case BulletType.M9:
                boxRender.material = mM9;
                maxCapacity = 9;
                type = 4;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetMagazine getMagazine = other.GetComponent<GetMagazine>();
            if(getMagazine.VerifyCompatibility(type))
            {
                getMagazine.ChangeMagazine(maxCapacity, projectile);
            }
        }
    }
}
