using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(SphereCollider))]
public class FireBall : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        projectile_name = "FireBall";
        this.gameObject.tag = "Projectile";
    }
}




