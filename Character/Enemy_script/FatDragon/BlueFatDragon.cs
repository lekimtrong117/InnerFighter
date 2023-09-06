using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFatDragon : FatDragon
{
    public override void OnShoot()
    {
        //damage calculation
        DamageData damageData = new DamageData();
        damageData.HP_Damage = 2 * attribute.current_Attack;
        damageData.SP_Damage = 10;
        damageData.elemental = Elemental.Water;
        //
        Projectile projectile = PrefabManager.Instance.CreateProjectile("SmallWaterSplash", trans.position + new Vector3(0, 0.8f, 0.5f), damageData, Target_tag.Player, false, true);
        projectile.FlyTo(player.transform.position, 14, 40);
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