using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleFatDragon : FatDragon
{
    public override void OnShoot()
    {
        //damage calculation
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 2 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Electric;
        Vector3 player_pos = player.transform.position;
        //
        PrefabManager.Instance.CreateRoundAlertThenCallBack(player.transform.position, 1,1, () =>
        {
            Projectile projectile = PrefabManager.Instance.CreateProjectile("Thunder", player_pos, damageData, Target_tag.Player, false, false);
            projectile.StayAT_IN(player_pos, 2);
        });
        shoot_count++;
        if (shoot_count >= 3)
        {
            GotoState(fly_state);
        }
        else
        {
            PrefabManager.Instance.CreateChamThan(trans, 11, 0.5f);
            dataBiding.Shoot = true;
        }
    }
}
