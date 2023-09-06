using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FatDragon_Die_State : FSM_State
{
    public FatDragon parent;
    float timer;
    public override void OnEnter()
    {
        parent.audioSource.PlayOneShot(parent.die);
        parent.dataBiding.Die = true;
    }
}
