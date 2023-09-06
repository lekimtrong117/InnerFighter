using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDash : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        projectile_name = "FireDash";
        this.gameObject.tag = "Projectile";
    }

}
