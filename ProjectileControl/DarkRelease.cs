using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRelease : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.projectile_name = "DarkRelease";
        this.gameObject.tag = "Projectile";
    }
}
