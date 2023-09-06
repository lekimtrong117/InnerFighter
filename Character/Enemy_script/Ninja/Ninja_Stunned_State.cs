using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Ninja_Stunned_State : FSM_State
{
    [NonSerialized] public Ninja parent;
    float timer = 0;
    public override void OnEnter()
    {
        timer = 0;
        base.OnEnter();
        parent.attribute.isStunning = true;
        parent.dataBiding.Stun = true;
        PrefabManager.Instance.CreateStunEffect(parent.trans, 1, parent.attribute.stun_duration);
    }
    public override void Update()
    {
        base.Update();
        if (parent.attribute.isAlive == false && parent.CurrentState != parent.die_State)
            parent.OnDeath();
        timer += Time.deltaTime;
        if (timer >= parent.attribute.stun_duration)
        {
            timer = 0;
            parent.GotoState(parent.previous_state);
        }
    }
    public override void Exit()
    {
        base.Exit();
        StunEffect effect = parent.gameObject.GetComponentInChildren<StunEffect>();
        if (effect != null)
        {
            PoolManager.Instance.DeSpawn("StunEffect", effect.transform);
        }
        timer = 0;
        parent.attribute.isStunning = false;
        parent.attribute.currentSP = 0;
        parent.dataBiding.Stun = false;
    }
}
