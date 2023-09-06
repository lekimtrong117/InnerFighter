using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWaterSplash : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        projectile_name = "SmallWaterSplash";
    }
}
