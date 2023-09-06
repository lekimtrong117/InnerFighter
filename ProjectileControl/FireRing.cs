using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        projectile_name = "FireRing";
        this.gameObject.tag = "Projectile";
    }
   
}
