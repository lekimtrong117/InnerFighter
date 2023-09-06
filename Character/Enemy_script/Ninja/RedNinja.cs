using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static RootMotion.Demos.Turret;

public class RedNinja : Ninja
{

    public override void OnThrow()
    {
        if (attribute.isAlive == true && attribute.isStunning == false)
        {
            ShurkikenCoolDownHandler();
            FireBall fireBall = PoolManager.Instance.Spawn("FireBall").gameObject.GetComponent<FireBall>();
            DamageData damageData = new DamageData();
            damageData.HP_Damage = attribute.current_Attack * 2;
            damageData.SP_Damage = 5;
            damageData.elemental = Elemental.Fire;
            fireBall.SetUp(trans.position+new Vector3(0,1,0), damageData, Target_tag.Player, false, true);
            fireBall.FlyTo(player.transform.position, 15, 40);
            throw_State.throw_done = true;
        }
    }
    public override void OnMelee()
    {
        //damage callculate
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 4 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Fire;
        //
        FireDash firedash = (FireDash)PrefabManager.Instance.CreateProjectile("FireDash", rightFoot.position, damageData, Target_tag.Player, false, false);
        firedash.FlyTo(player.transform.position, 30, 10);
    }
}
