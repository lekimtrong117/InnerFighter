using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Orc_Stun_State : FSM_State
{
    public Orc parent;
    float timer;
    Transform stuneffect;
    public override void OnEnter()
    {
        base.OnEnter();
        stuneffect = PrefabManager.Instance.CreateStunEffect(parent.trans, 3, parent.attribute.stun_duration);
        timer = 0;
        parent.dataBiding.Stun = true;
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
        parent.dataBiding.Stun = false;
        parent.attribute.isStunning = false;
        parent.attribute.currentSP = 0;
        if (stuneffect != null)
        {
            PoolManager.Instance.DeSpawn("StunEffect", stuneffect);
        }
    }

}

