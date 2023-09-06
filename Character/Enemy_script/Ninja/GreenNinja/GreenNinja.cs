using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenNinja : Ninja
{
    public override void OnThrow()
    {
        ShurkikenCoolDownHandler();
        RockSpike rockspike = PoolManager.Instance.Spawn("RockSpike").gameObject.GetComponent<RockSpike>();
        DamageData damageData = new DamageData();
        damageData.HP_Damage = attribute.current_Attack * 2;
        damageData.SP_Damage = 7.5f;
        damageData.elemental = Elemental.Grass;
        rockspike.SetUp(rightFoot.position, damageData, Target_tag.Player, false, true);
        rockspike.FlyTo(player.transform.position, 15, 15);
        throw_State.throw_done = true;
    }
    public override void OnMelee()
    {
        //damage callculate
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 4 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Grass;
        //
        RockSpike rockspike = PoolManager.Instance.Spawn("RockSpike").gameObject.GetComponent<RockSpike>();
        rockspike.SetUp(rightFoot.position, damageData, Target_tag.Player, false, true);
        rockspike.FlyTo(rightFoot.position+trans.forward*5, 10, 7);
    }
}
   

