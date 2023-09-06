using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Ninja_Throw_State : FSM_State
{
    //drag in component
    [NonSerialized] public Ninja parent;
    //m_var
    [NonSerialized] public bool throw_done = false;
    public override void OnEnter()
    {
        base.OnEnter();
        throw_done = false;
        parent.dataBiding.Throw = true;
    }
    public override void Update()
    {
        base.Update();
        if (parent.attribute.isAlive == false && parent.CurrentState != parent.die_State)
            parent.OnDeath();
        parent.trans.forward = parent.dirToPlayer;
        if (throw_done)
        {
            if (parent.distance_to_player <= parent.melee_Distance)
            {
                parent.GotoState(parent.melee_State);
            }
            else
                parent.GotoState(parent.run_State);
        }   
    }
    

}
