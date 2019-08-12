using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private enum GunEquiped
    {
        Shotgun = 1,
        M4 = 2,
        Ak47,
        M9
    }

    [SerializeField] private GunEquiped gunType = GunEquiped.M9;

    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform gunTip = null;
    [SerializeField] private float backspinDrag = 0.02f;

    private float springForce = 1.49f;

    private void Awake()
    {
        
    }

    public void Shoot()
    {
        GameObject project;
        project = Instantiate(projectile, gunTip.position, gameObject.transform.rotation);

        project.GetComponent<BbsProperties>().BackspinDrag = backspinDrag;

        project.GetComponent<Rigidbody>().AddForce(springForce * gameObject.transform.forward);
    }

    public GameObject SetProjectile
    {
        set
        {
            projectile = value;
        }
    }
}
