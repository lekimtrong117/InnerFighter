using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using DG.Tweening;

[Serializable]
public class FireBoss_Ground_FastRun_State : FSM_State
{
    public FireBoss parent;
    float timer_state = 0;
    public DamageData damage = new DamageData();
    public float state_dur = 5;
    public float shoot_rate = 2;
    public float fast_run_time;
   bool Isrunning;
    public float chamthan_height;

    public override void OnEnter()
    {
        base.OnEnter();
        //
        if (parent.previous_state != parent.stun_state)
            parent.run_count++;
        if (parent.run_count > 2)
            parent.run_count = 0;
        timer_state = 0;
        //
        parent.dataBiding.Charge = true;
        PrefabManager.Instance.CreateChamThan(parent.head, chamthan_height, state_dur);
        Isrunning = false;
    }
    public override void Update()
    {
        base.Update();
        timer_state += Time.deltaTime;
        if (timer_state >= state_dur&&Isrunning==false)
        {
            timer_state = 0;
            Isrunning = true;
            Vector3 pos = parent.player.transform.position;
            parent.animator.Play("LocoMotion");
            parent.dataBiding.Run = 0;
            parent.characterController.enabled = false;
            parent.trans.DOMove(pos, fast_run_time).OnComplete(() =>
            {
                parent.characterController.enabled = true;
                if (parent.CurrentState == parent.ground_fastRun_State)
                    parent.GotoState(parent.ground_melee_state);
            }
            );
        }
    }
    public override void Exit()
    {
        base.Exit();
        Isrunning = false;
        parent.characterController.enabled = true;
        parent.trans.DOKill();
    }
}
