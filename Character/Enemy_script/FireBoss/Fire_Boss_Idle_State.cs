using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Fire_Boss_Idle_State : FSM_State
{
    float timer;
    public float state_dur = 3.9f;
 public   FireBoss parent;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.idlesound);
        PrefabManager.Instance.CreateNPCDialog(parent.trans, new Vector3(0, parent.dialog_height, 5), "Feel My Fury", 10, Color.red,3);
        parent.dataBiding.Idle = true;
        timer = 0;
    }
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if(timer>=state_dur)
        {
            timer = 0;
            parent.GotoState(parent.run_state);
        }
    }

}
