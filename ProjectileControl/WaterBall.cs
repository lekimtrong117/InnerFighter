using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        this.projectile_name = "WaterBall";
    }
   
}
    

