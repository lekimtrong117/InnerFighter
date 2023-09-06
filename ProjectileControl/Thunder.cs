using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Projectile
{
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        this.projectile_name = "Thunder";
    }
    public override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == this.target_tag.ToString())
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (enemy.attribute.isStunning)
                {
                    this.damageData.HP_Damage = this.damageData.HP_Damage * 2;
                    PrefabManager.Instance.CreatePopUpText(this.trans.position+new Vector3(0,2,0), "X2", 30, Color.yellow);
                }
            }
            collider.gameObject.GetComponent<CharacterOnDamageHandler>().OnDamge(this.damageData);
        }
        // khi 2 projectile collide
        if (collider.gameObject.tag == "Projectile")
        {
         
            Projectile colliProjectile = collider.gameObject.GetComponent<Projectile>();
            //yena projectile will deflect enemy projectile
            if (this.target_tag == Target_tag.Enemy && colliProjectile.target_tag == Target_tag.Player)
                // only if project can be deflect
                if (colliProjectile.canbe_deflected && this.can_deflect)
                {
                    PopUpDeflect(colliProjectile.trans.position);
                    colliProjectile.SetUp(colliProjectile.trans.position, colliProjectile.damageData, Target_tag.Enemy, false, false);
                    // deflected project will reverse direction and fly with delfected_fly_speed , not before speed
                    colliProjectile.FlyTo(colliProjectile.trans.position - colliProjectile.trans.forward * 30, deflected_fly_speed, 30);
                }
        }
    }
}
