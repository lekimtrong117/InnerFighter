using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FatDragon_StunState : FSM_State
{
    public FatDragon parent;
    float timer;
    public override void OnEnter()
    {
        base.OnEnter();
        PrefabManager.Instance.CreateStunEffect(parent.trans, 9, parent.attribute.stun_duration);
        timer = 0;
        parent.animator.Play("Fly");
    }
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer >= parent.attribute.stun_duration)
        {
            timer = 0;
            parent.GotoState(parent.previous_state);
        }
    }
    public override void Exit()
    {
        timer = 0;
        parent.attribute.isStunning = false;
        parent.attribute.currentSP = 0;
        StunEffect effect = parent.gameObject.GetComponentInChildren<StunEffect>();
        if (effect != null)
        {
            PoolManager.Instance.DeSpawn("StunEffect", effect.transform);
        }
    }
}
