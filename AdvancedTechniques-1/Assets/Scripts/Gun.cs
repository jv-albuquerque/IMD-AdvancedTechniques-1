using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform gunTip = null;
    [SerializeField] private float backspinDrag = 0.02f;
    private float springForce = 1.49f;

    public void Shoot()
    {
        GameObject project;
        project = Instantiate(projectile, gunTip.position, transform.rotation);
        project.GetComponent<BbsProperties>().BackspinDrag = backspinDrag;
        project.GetComponent<Rigidbody>().AddForce(0f, 0f, springForce);
    }
}
