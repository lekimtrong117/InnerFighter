using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FatDragon_Shoot_State : FSM_State
{
    public FatDragon parent;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.shoot);
        parent.shoot_count = 0;
        parent.trans.forward = parent.dirToPlayer;
        PrefabManager.Instance.CreateChamThan(parent.trans,11, 0.5f);
        parent.dataBiding.Shoot = true;
    }
    public override void Update()
    {
        base.Update();
        parent.trans.forward = parent.dirToPlayer;
    }
    public override void Exit()
    {
        base.Exit();
        parent.shoot_count = 0;
    }

}
