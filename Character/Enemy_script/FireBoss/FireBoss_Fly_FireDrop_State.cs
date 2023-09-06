using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Fly_FireDrop_State :FSM_State
{
    public FireBoss parent;
    float timer_state;
    float timer_shoot;
    public float state_dur=7;
    public float shoot_rate=2;
    DamageData damage=new DamageData();
    //
    Vector3 fly_dir;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.charge_sound);
        if (parent.previous_state != parent.stun_state)
            parent.fly_count++;
        if (parent.fly_count > 2)
            parent.fly_count = 0;
        parent.animator.Play("LocoMotion");
        parent.dataBiding.Run = 1;
        timer_state = 0;
        timer_shoot = 0;
        var q = Quaternion.Euler(0, 60, 0);
        fly_dir=q*parent.dirToPlayer;
    }
    public override void Update()
    {
        base.Update();
        timer_state += Time.deltaTime;
        timer_shoot += Time.deltaTime;
        parent.characterController.Move(fly_dir * parent.attribute.run_Speed * Time.deltaTime);
        if (timer_shoot >= shoot_rate)
        {
            timer_shoot = 0;
            //dame calulate
            //damage callculate
            damage.HP_Damage = 2 * parent.attribute.current_Attack;
            damage.SP_Damage = 10;
            damage.elemental = Elemental.Fire;
            Vector3 player_pos = parent.player.transform.position;
            //
            PrefabManager.Instance.CreateRoundAlertThenCallBack(parent.player.transform.position, 1, 1, () =>
            {
                Projectile firering = PrefabManager.Instance.CreateProjectile("FireRing", player_pos, damage, Target_tag.Player, false, false);
                firering.StayAT_IN(firering.trans.position, 0.5f);
            });
        }
        if (timer_state >= state_dur)
        {
            timer_state = 0;
            parent.GotoState(parent.fly_State);
        }
    }

}
