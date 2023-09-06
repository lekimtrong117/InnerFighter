using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Run_State : FSM_State
{
    public FireBoss parent;
    float timer_run=0;
    float timer_shoot = 0;
    public DamageData damage=new DamageData();
    public float state_dur=5;
    public float shoot_rate = 2;
    public float speed_scale;
    public float parent_head_height;
    public override void OnEnter()
    {
        base.OnEnter();
        PrefabManager.Instance.CreateNPCDialog(parent.trans, new Vector3(0, parent.dialog_height, 5), "RUN! RAT RUN", 10, Color.red, 3);
        parent.animator.Play("LocoMotion");
        parent.dataBiding.Run = 0;
        timer_run = 0;
        timer_shoot = 0;
        parent.trans.forward = parent.dirToPlayer;
        parent.attribute.isBlocking = true;
        parent.audioSource.PlayOneShot(parent.runsound);
    }
    public override void Update()
    {
        base.Update();
        ////TEMPORARY
        parent.attribute.canbePush = false;
        //
        timer_run+=Time.deltaTime;
        timer_shoot += Time.deltaTime;
        parent.trans.forward = parent.dirToPlayer;
        if (parent.distance_to_player >= 0.5f)
            parent.characterController.Move(parent.trans.forward * parent.attribute.run_Speed * Time.deltaTime * speed_scale);
        if (timer_shoot >=shoot_rate)
        {
            IEnumerator delay_spawnCHamthan = SpawnChamThan();
            ScenceManager.Instance.StartCoroutine(delay_spawnCHamthan);
            timer_shoot = 0;
            //dame calulate
            damage.HP_Damage = 2 * parent.attribute.current_Attack;
            damage.SP_Damage = 5;
            damage.elemental = Elemental.Fire;
            //
            Projectile fireball = PrefabManager.Instance.CreateProjectile("FireBall", parent.head.position, damage, Target_tag.Player, false, true);
            fireball.FlyTo(parent.player.transform.position,30,100);
            Projectile rockspike = PrefabManager.Instance.CreateProjectile("RockSpike", parent.trans.position, damage, Target_tag.Player, false, true);
            rockspike.FlyTo(parent.player.transform.position+new Vector3(0,0,3),40, 100);
            Projectile rockspike2 = PrefabManager.Instance.CreateProjectile("RockSpike", parent.trans.position, damage, Target_tag.Player, false, true);
            rockspike2.FlyTo(parent.player.transform.position + new Vector3(0, 0, -3), 40, 100);
        }
        if (timer_run>=state_dur)
        {
            timer_run = 0;
            parent.GotoState(parent.run_next_state[parent.run_count]);
        }
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
       
    }
    IEnumerator SpawnChamThan()
    {
        yield return new WaitForSeconds(shoot_rate - 0.5f);
        if (parent.CurrentState == parent.run_state) 
        PrefabManager.Instance.CreateChamThan(parent.head, parent_head_height, 0.5f);
    }
    public override void Exit()
    {
        base.Exit();
        parent.attribute.isBlocking = false;
    }
}
