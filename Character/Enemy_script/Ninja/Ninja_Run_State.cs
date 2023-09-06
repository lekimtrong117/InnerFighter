using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Ninja_Run_State : FSM_State
{
    //drag in component
    [NonSerialized]public Ninja parent;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.animator.Play("LocoMotion");
        parent.dataBiding.Run = 1;
    }
    public override void Update()
    {
        base.Update();
        if (parent.attribute.isAlive == false && parent.CurrentState != parent.die_State)
            parent.OnDeath();
        // state transit
        if (parent.distance_to_player <= parent.melee_Distance)
        {
            parent.GotoState(parent.melee_State);
        }
        else if (parent.distance_to_player <= parent.throw_Distance && parent.shuriken_is_available)
        {
            parent.GotoState(parent.throw_State);
        }
        else
        {
            Vector3 dirMove = parent.player.transform.position - parent.transform.position;
            dirMove.y = 0;
            dirMove.Normalize();
            parent.transform.forward = dirMove;
            // move by character controller
            parent.moveVector3D.x = dirMove.x;
            parent.moveVector3D.z = dirMove.z;
            parent.moveVector3D.y = 0;// gravity se dc xu ly trong ham update cua class Enemy
            parent.characterController.Move(parent.moveVector3D*Time.deltaTime*parent.attribute.run_Speed);
        }
    }
    public override void Exit()
    {
        base.Exit();
        parent.dataBiding.Run = 0;
    }

}
