using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Orc_Attack_State : FSM_State
{
    public Orc parent;
    public override void OnEnter()
    {
        base.OnEnter();
        PrefabManager.Instance.CreateChamThan(parent.trans, 3, 1);
        parent.dataBiding.Attack = true;
        parent.transform.forward = parent.dirToPlayer;
    }
}
