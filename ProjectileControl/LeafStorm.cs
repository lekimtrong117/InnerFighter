using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafStorm : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        this.projectile_name = "LeafStorm";
    }
}
