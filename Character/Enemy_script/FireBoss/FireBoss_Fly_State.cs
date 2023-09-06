using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Fly_State : FSM_State
{
    public FireBoss parent;
    float timer_state;
    float timer_shoot;
    public float state_dur = 7;
    public float shoot_rate = 2;
    public float leaf_storm_dis_from_player;
    DamageData damage = new DamageData();
    public float storm_dur;
    public float speed_scale = 2;
    Quaternion q;

    public override void OnEnter()
    {
        base.OnEnter();
        PrefabManager.Instance.CreateNPCDialog(parent.trans, new Vector3(0, parent.dialog_height, 5), "My wing upon you", 10, Color.red, 3);
        parent.audioSource.PlayOneShot(parent.flysound);
        parent.animator.Play("LocoMotion");
        parent.dataBiding.Run = 1;
        timer_state = 0;
        timer_shoot = 0;
        parent.trans.forward = parent.dirToPlayer;
        parent.attribute.isBlocking = true;
        //dame calulate
        DamageData dam2 = new DamageData();
        dam2.HP_Damage = 2 * parent.attribute.current_Attack;
        dam2.SP_Damage = 5;
        dam2.elemental = Elemental.Fire;
        for (int i = 0; i < 6; i++)
        {

            q = Quaternion.Euler(0, 60 * i, 0);
            Vector3 dir = q * parent.player.transform.forward;
            Vector3 pos = parent.player.transform.forward + dir * leaf_storm_dis_from_player + parent.player.transform.position;
            var storm = PrefabManager.Instance.CreateProjectile("LeafStorm", pos, dam2, Target_tag.Player, false,true);
            storm.StayAT_IN(pos, storm_dur);
        }
    }
    public override void Update()
    {
        base.Update();
        timer_state += Time.deltaTime;
        timer_shoot += Time.deltaTime;
        parent.trans.forward = parent.dirToPlayer;
        if (parent.distance_to_player >= 0.5f)

            parent.characterController.Move(parent.trans.forward * parent.attribute.run_Speed*speed_scale * Time.deltaTime);
        if (timer_shoot >= shoot_rate)
        {
            timer_shoot = 0;
            //dame calulate
            damage.HP_Damage = 2 * parent.attribute.current_Attack;
            damage.SP_Damage = 5;
            damage.elemental = Elemental.Fire;
            //
            Projectile fireball = PrefabManager.Instance.CreateProjectile("FireBall", parent.trans.position + new Vector3(0, 1, 4), damage, Target_tag.Player, false, true);
            fireball.FlyTo(parent.player.transform.position, 15, 40);
            // summon storm
            //
            //
            DamageData dam2 = new DamageData();
            dam2.HP_Damage = 2 * parent.attribute.current_Attack;
            dam2.SP_Damage = 5;
            dam2.elemental = Elemental.Fire;
            for (int i = 0; i < 6; i++)
            {
                q = Quaternion.Euler(0, 60 * i, 0);
                Vector3 dir = q * parent.player.transform.forward;
                Vector3 pos = parent.player.transform.forward + dir * leaf_storm_dis_from_player + parent.player.transform.position;
                var storm = PrefabManager.Instance.CreateProjectile("LeafStorm", pos, dam2, Target_tag.Player, false, true);
                storm.StayAT_IN(pos, storm_dur);
            }
            ///
        }
        if (timer_state >= state_dur)
        {
            timer_state = 0;
            parent.GotoState(parent.fly_next_state[parent.fly_count]);
        }
    }
    public override void Exit()
    {
        base.Exit();
        parent.attribute.isBlocking = false;
    }

}
