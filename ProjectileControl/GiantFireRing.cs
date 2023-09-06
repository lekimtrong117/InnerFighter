using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFireRing : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.projectile_name = "GiantFireRing";
        this.gameObject.tag = "Projectile";
    }
}
