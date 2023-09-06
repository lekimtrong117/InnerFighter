using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteNinja : Ninja
{
    public override void OnThrow()
    {
        ShurkikenCoolDownHandler();
        IceLance rockspike = PoolManager.Instance.Spawn("IceLance").gameObject.GetComponent<IceLance>();
        DamageData damageData = new DamageData();
        damageData.HP_Damage = attribute.current_Attack * 2;
        damageData.SP_Damage = 7.5f;
        damageData.elemental = Elemental.Ice;
        rockspike.SetUp(righthand.position, damageData, Target_tag.Player, false, true);
        rockspike.FlyTo(player.transform.position, 15, 40);
        throw_State.throw_done = true;

    }
    public override void OnMelee()
    {
        //damage callculate
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 4 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Ice;
        //
        Vector3 dir_to_player = (player.transform.position - trans.position).normalized;
        dir_to_player.y = 0;
        Vector3 sword_pos = rightFoot.position + dir_to_player * 3;
        PrefabManager.Instance.CreateRoundAlertThenCallBack(sword_pos,1,1, () =>
        {
            IceSword icesword = PoolManager.Instance.Spawn("IceSword").gameObject.GetComponent<IceSword>();
            icesword.SetUp(sword_pos, damageData, Target_tag.Player, false, false);
            icesword.trans.forward = dir_to_player;
            icesword.PlaySwordAnim();
            icesword.StayAT_IN(sword_pos, 0.5f);
        });




    }
}
