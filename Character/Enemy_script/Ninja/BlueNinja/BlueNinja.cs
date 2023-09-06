using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNinja : Ninja

{ 
    public override void OnThrow()
    {
        ShurkikenCoolDownHandler();
        SmallWaterSplash smallwaterSplash = PoolManager.Instance.Spawn("SmallWaterSplash").gameObject.GetComponent<SmallWaterSplash>();
        DamageData damageData = new DamageData();
        damageData.HP_Damage = attribute.current_Attack * 2;
        damageData.SP_Damage = 7.5f;
        damageData.elemental = Elemental.Water;
        smallwaterSplash.SetUp(trans.position + new Vector3(0, 1, 0), damageData, Target_tag.Player, false, true);
        smallwaterSplash.FlyTo(player.transform.position, 15, 40);
        throw_State.throw_done = true;
    }
    public override void OnMelee()
    {
        //damage callculate
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 4 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Water;
        //
        WaterSplash watersplash = (WaterSplash)PrefabManager.Instance.CreateProjectile("WaterSplash", rightFoot.position, damageData, Target_tag.Player, false, false);
        watersplash.StayAT_IN(rightFoot.position, 0.2f);
    }
   
}
