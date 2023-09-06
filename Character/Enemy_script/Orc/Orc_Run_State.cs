using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Orc_Run_State : FSM_State
{
    public Orc parent;
    FSM_State next_state;
    
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.runsound);
        parent.dataBiding.Run = 1;
        parent.attribute.isBlocking = true;
        parent.trans.forward = parent.dirToPlayer;
    }
    public override void OnEnter(object data)
    {
        //TEMP
        if (parent.CurrentState == parent.run_state)
            parent.attribute.isBlocking = true;
        //
        base.OnEnter(data);
        parent.dataBiding.Run = 1;
        next_state = (FSM_State)data;
        parent.attribute.isBlocking = true;
        parent.trans.forward = parent.dirToPlayer;
    }
    public override void Update()
    {
        if (parent.CurrentState == parent.run_state)
            parent.attribute.isBlocking = true;
        //
        parent.trans.forward = parent.dirToPlayer;
        parent.characterController.Move(parent.dirToPlayer * parent.attribute.run_Speed * Time.deltaTime);
        if (parent.distance_to_player < 2)
            parent.GotoState(next_state);
    }
    public override void Exit()
    {
        base.Exit();
        parent.attribute.isBlocking = false;
        parent.dataBiding.Run = 0;
    }
}

