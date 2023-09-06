using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleNinja : Ninja
{
    public override void OnThrow()
    {
        ShurkikenCoolDownHandler();
        ElectricBall electricball = PoolManager.Instance.Spawn("ElectricBall").gameObject.GetComponent<ElectricBall>();
        DamageData damageData = new DamageData();
        damageData.HP_Damage = attribute.current_Attack * 2;
        damageData.SP_Damage = 30;
        damageData.elemental = Elemental.Electric;
        electricball.SetUp(trans.position + new Vector3(0, 1, 0), damageData, Target_tag.Player, false, true);
        electricball.FlyTo(player.transform.position, 15, 40);
        throw_State.throw_done = true;
    }
    public override void OnMelee()
    {
        //damage callculate
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 4 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Electric;
        //
        ElectricBall electricball = PoolManager.Instance.Spawn("ElectricBall").gameObject.GetComponent<ElectricBall>();
        electricball.SetUp(righthand.position, damageData, Target_tag.Player, false, true);
        electricball.FlyTo(trans.position+trans.forward*10,10, 40);
    }
}
