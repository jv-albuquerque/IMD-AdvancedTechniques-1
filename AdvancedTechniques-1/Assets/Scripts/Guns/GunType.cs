using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunType : MonoBehaviour
{
    protected Transform gunTip;

    protected float backspinDrag;
    protected float springForce;
    protected float delayToShoot;
    protected float spread;

    public abstract void Shoot(GameObject projectile, Transform gunTransform);

    public abstract string GetModel { get;}

    public abstract Transform GetGunTip { get; set; }

    //the defalt values of the gun
    public abstract float GetBackspinDrag { get; set; }
    public abstract float GetSpringForce { get; set; }
    public abstract float GetDelayToShoot { get; set; }
}
