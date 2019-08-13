﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : GunType
{
    public Shotgun()
    {
        springForce = 1.49f;
        delayToShoot = .25f;
        backspinDrag = 0.02f;
        spread = 9.0f;
    }

    public override string GetModel => "M9";

    public override Transform GetGunTip { get => gunTip; set => gunTip = value; }
    public override float GetBackspinDrag { get => backspinDrag; set => backspinDrag = value; }
    public override float GetSpringForce { get => springForce; set => springForce = value; }
    public override float GetDelayToShoot { get => delayToShoot; set => delayToShoot = value; }

    public override void Shoot(GameObject projectile, Transform gunTransform)
    {
        GameObject project;

        for (int i = 0; i < 3; i++)
        {
            project = Instantiate(projectile, gunTip.position, gunTransform.rotation);
            project.GetComponent<BbsProperties>().BackspinDrag = backspinDrag;
            project.GetComponent<Rigidbody>().AddForce(springForce * gunTransform.forward);
            project.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * spread;
        }
    }
}
