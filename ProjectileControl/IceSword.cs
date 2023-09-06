using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSword : Projectile
{
    public Animator animator;
    public static bool slash_left;
    public override void DeclareProjectileNameAndTag()
    {
        projectile_name = "IceSword";
        this.gameObject.tag = "Projectile";
    }
    public void PlaySwordAnim()
    {
        if (slash_left)
        {
            animator.Play("SlashLeft");
            slash_left = false;
        }
        else
        {
            animator.Play("SlashRight");
            slash_left=true;
        }
        
    }

}
