using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        projectile_name = "ElectricBall";
    }
}
