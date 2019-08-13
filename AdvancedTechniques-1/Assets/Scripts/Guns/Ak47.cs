using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : GunType
{
    public Ak47()
    {
        springForce = 1.49f;
        delayToShoot = .1f;
        backspinDrag = 0.02f;
        spread = 5.0f;
    }

    public override string GetModel => "M9";

    public override Transform GetGunTip { get => gunTip; set => gunTip = value; }
    public override float GetBackspinDrag { get => backspinDrag; set => backspinDrag = value; }
    public override float GetSpringForce { get => springForce; set => springForce = value; }
    public override float GetDelayToShoot { get => delayToShoot; set => delayToShoot = value; }

    public override void Shoot(GameObject projectile, Transform gunTransform)
    {
        GameObject project;
        project = Instantiate(projectile, gunTip.position, gunTransform.rotation);

        project.GetComponent<BbsProperties>().BackspinDrag = backspinDrag;

        project.GetComponent<Rigidbody>().AddForce(springForce * gunTransform.forward);

        project.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * spread;
    }
}
