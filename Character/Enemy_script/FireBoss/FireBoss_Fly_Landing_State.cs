using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
[Serializable]
public class FireBoss_Fly_Landing_State : FSM_State
{
    public FireBoss parent;
    DamageData damage = new DamageData();
    public float land_damgage_scale = 20;
    public float jump_force = 10;
    public float jump_time = 1.5f;
    Thunder thunder;
    public float thunder_tracking_speed;
    float timer_state;
    public float state_dur = 3;
    public int nums_jump;
    public float fly_up_dur;
    public Vector3 fly_up_to;
    public float height_before_fly_up;
    public override void OnEnter()
    {

        base.OnEnter();
        PrefabManager.Instance.CreateNPCDialog(parent.trans, new Vector3(0, parent.dialog_height, 5), "How about this", 10, Color.red, 3);
        parent.audioSource.PlayOneShot(parent.flysound);
        if (parent.previous_state != parent.stun_state)
            parent.fly_count++;
        if (parent.fly_count > 2)
            parent.fly_count = 0;
        parent.animator.Play("LocoMotion");
        parent.dataBiding.Run = 1;
        timer_state = 0;
        parent.trans.forward = parent.dirToPlayer;
        DamageData dam2 = new DamageData();
        dam2.HP_Damage = 1 * parent.attribute.current_Attack;
        dam2.SP_Damage = 10;
        dam2.elemental = Elemental.Fire;
        thunder = PoolManager.Instance.Spawn("Thunder").GetComponent<Thunder>();
        thunder.SetUp(parent.transform.position,dam2, Target_tag.Player, false, false);
    }
    public override void Update()
    {
        base.Update();
        timer_state += Time.deltaTime;
        parent.trans.forward = parent.dirToPlayer;
        if (timer_state < state_dur)
        {
            thunder.trans.position = Vector3.Lerp(thunder.trans.position, parent.player.transform.position, Time.deltaTime * thunder_tracking_speed);
        }
        else
        {
            timer_state = 0;
            damage.HP_Damage = land_damgage_scale * parent.attribute.current_Attack;
            damage.SP_Damage = 10;
            damage.elemental = Elemental.Fire;
            parent.characterController.enabled = false;
            parent.trans.position = parent.player.transform.position + new Vector3(0,height_before_fly_up,7);
            Vector3 pos = parent.player.transform.position;
            parent.trans.DOMove(parent.trans.position + fly_up_to, fly_up_dur).OnComplete(() =>
            {
                if (parent.CurrentState == parent.Fly_Landing_State)
                {
                    parent.trans.DOJump(pos, jump_force, nums_jump, jump_time).OnComplete(() =>
                    {
                        parent.characterController.enabled = true;
                        var firering = PrefabManager.Instance.CreateProjectile("GiantFireRing", parent.trans.position, damage, Target_tag.Player, false, false);
                        firering.StayAT_IN(firering.trans.position, 2);
                        if (parent.CurrentState == parent.Fly_Landing_State)
                            parent.GotoState(parent.run_state);  
                    });
                }
            });

        }
    }
    public override void Exit()
    {
        base.Exit();
        if (thunder != null)
        { PoolManager.Instance.DeSpawn("Thunder", thunder.trans); }
        parent.trans.DOKill();
        parent.characterController.enabled = true;
        parent.trans.position = new Vector3(parent.trans.position.x, 0, parent.trans.position.z);
    }
}


