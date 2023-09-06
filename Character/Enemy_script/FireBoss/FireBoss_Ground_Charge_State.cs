using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Ground_Charge_State : FSM_State
{
    public FireBoss parent;
     float timer_shoot;
     float timer_state;
    public float state_dur = 5;
    public float shoot_rate = 1;
    public DamageData damage = new DamageData();
    public float chare_damgae_scale = 20;
    public float charger_range;
    public Transform roundAlert;
    public float zoom_speed;
    public float fire_ring_time;
    public override void OnEnter()
    {
        base.OnEnter();
        PrefabManager.Instance.CreateNPCDialog(parent.trans, new Vector3(0, parent.dialog_height, 5), "Im the king of fire and anger", 10, Color.red, 3);
        parent.audioSource.PlayOneShot(parent.charge_sound);
        if (parent.previous_state != parent.stun_state)
            parent.run_count++;
        if (parent.run_count > 2)
            parent.run_count = 0;
        parent.dataBiding.Charge = true;
        parent.trans.forward = parent.dirToPlayer;
        timer_shoot = 0;
        timer_state = 0;
        roundAlert = PoolManager.Instance.Spawn("RoundAlert");
        roundAlert.SetParent(parent.trans);
        roundAlert.position = parent.trans.position;
        roundAlert.localScale = Vector3.one;
    }
    public override void Update()
    {
        base.Update();
        timer_state += Time.deltaTime;
        timer_shoot += Time.deltaTime;
        roundAlert.localScale += new Vector3(1, 0, 1) * Time.deltaTime * zoom_speed;
        if (timer_shoot>=shoot_rate)
        {
            timer_shoot=0;
            //damage callculate
            damage.HP_Damage = 2 * parent.attribute.current_Attack;
            damage.SP_Damage = 10;
            damage.elemental = Elemental.Fire;
            Vector3 player_pos = parent.player.transform.position;
            //
            PrefabManager.Instance.CreateRoundAlertThenCallBack(parent.player.transform.position,0.5f, 1, () =>
            {
                Projectile firering = PrefabManager.Instance.CreateProjectile("FireRing", player_pos, damage, Target_tag.Player, false, false);
                firering.StayAT_IN(firering.trans.position, 0.5f);
            });
        }
        if (timer_state>=state_dur)
        {
            timer_state = 0;
            DamageData damage2 = new DamageData();
            damage2.HP_Damage = chare_damgae_scale * parent.attribute.current_Attack;
            damage2.SP_Damage = 10;
            damage2.elemental = Elemental.Fire;
            Projectile firering = PrefabManager.Instance.CreateProjectile("GiantFireRing", parent.trans.position, damage2, Target_tag.Player, false, false);
            firering.StayAT_IN(parent.trans.position,fire_ring_time);
            if(roundAlert!=null)
            {
                roundAlert.localScale = Vector3.one;
                PoolManager.Instance.DeSpawn("RoundAlert", roundAlert);
            }   
            parent.GotoState(parent.fly_State);
        }
      
    }
    public override void Exit()
    {
        base.Exit();
        if (roundAlert != null)
        {
            roundAlert.localScale = Vector3.one;
            PoolManager.Instance.DeSpawn("RoundAlert", roundAlert);
        }

    }
}
