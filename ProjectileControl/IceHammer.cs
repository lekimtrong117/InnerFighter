using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceHammer : Projectile
{
    public Animator animator;
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        this.projectile_name = "IceHammer";
            }
    public override void OnTriggerEnter(Collider collider)
    {
        /// push enemy back
        /// 
        if (collider.gameObject.tag == "Enemy" && this.target_tag == Target_tag.Enemy)
        {
            Vector3 push_back_dir = (collider.transform.position - this.transform.position).normalized;
            push_back_dir.y = 0;
            Vector3 push_bacK_pos = collider.transform.position + push_back_dir * 5f * Yena.Instance.attribute.push_bacK_multiply;
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy.attribute.canbePush && enemy.attribute.isAlive == true)
            {
                enemy.OnBeingPushBack();
                enemy.characterController.enabled = false;
                collider.gameObject.transform.DOMove(push_bacK_pos, 0.5f).OnComplete(() =>
                {
                    enemy.characterController.enabled = true;
                });
            }
        }

        if (collider.gameObject.tag == this.target_tag.ToString())
        {
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
