using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(CapsuleCollider))]
public class WaterSplash : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        projectile_name = "WaterSplash";
        this.gameObject.tag = "Projectile";
    }
}
