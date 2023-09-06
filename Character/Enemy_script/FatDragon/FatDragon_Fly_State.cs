using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FatDragon_Fly_State : FSM_State
{
    public FatDragon parent;
    public float fly_dis;
    public Vector3 fly_dir;
    public float max_fly_dis = 10;
    Quaternion q;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.fly);
        parent.animator.Play("Fly");
        fly_dis = 0;
        switch (parent.fly_count)
        {
            case 0:
                {
                    fly_dir = parent.dirToPlayer;
                    break;
                }
            case 1:
                {
                    q = Quaternion.Euler(0, 60, 0);
                    fly_dir = q * parent.dirToPlayer;
                    break;
                }
            default:
                {
                    q = Quaternion.Euler(0, -60, 0);
                    fly_dir = q * parent.dirToPlayer;
                    break;
                }
        }
    }
    public override void Update()
    {
        base.Update();
        parent.trans.forward = fly_dir;
        parent.characterController.Move(fly_dir * Time.deltaTime * parent.attribute.run_Speed);
        fly_dis += (fly_dir * Time.deltaTime * parent.attribute.run_Speed).magnitude;
        if (fly_dis >= max_fly_dis)
            parent.GotoState(parent.shoot_state);

    }
    public override void Exit()
    {
        base.Exit();
        parent.fly_count++;
        if (parent.fly_count >= 3)
            parent.fly_count = 0;
    }


}
