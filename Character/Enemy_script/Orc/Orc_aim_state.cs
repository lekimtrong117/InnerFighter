using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Orc_aim_state : FSM_State
{
    public Orc parent;
    public Vector3 arrowoffset= new Vector3(0,0,0);
    public Transform arrow;
    public float lerp_speed = 2;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.aimsound);
        parent.trans.forward = parent.dirToPlayer;
        parent.dataBiding.Aim = true;
        arrow = PoolManager.Instance.Spawn("ArrowAlert");
        arrow.SetParent(parent.trans);
        arrow.localPosition = arrowoffset;
    }
    public override void Update()
    {
        base.Update();
        parent.trans.forward = Vector3.Lerp(parent.trans.forward, parent.dirToPlayer, Time.deltaTime * lerp_speed);
        arrow.forward=parent.dirToPlayer; 
    }
    public override void Exit()
    {
        base.Exit();
        PoolManager.Instance.DeSpawn("ArrowAlert", arrow);
    }

}
