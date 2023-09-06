using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Ninja_Idle_State : FSM_State
{
    [NonSerialized]public Ninja parent;
    //m_var
    public float delay_Idle = 2;
    private float timer_delay = 0;
    public override void OnEnter()
    {
        base.OnEnter();
        //look at player
        Vector2 dirmove = parent.player.gameObject.transform.position - parent.gameObject.transform.position;
        dirmove.y = 0;
        parent.transform.forward = dirmove;
        //init
        parent.animator.Play("LocoMotion");
        parent.dataBiding.Run = 0;
        timer_delay = 0;
    }
    public override void Update()
    {
        base.Update();
        if (parent.attribute.isAlive == false && parent.CurrentState != parent.die_State)
            parent.OnDeath();
        // after delay time, go to run state
        timer_delay +=Time.deltaTime;
        if (timer_delay>=delay_Idle)
        {
            timer_delay = 0;
            parent.GotoState(parent.run_State);
        }
       
    }

}   

