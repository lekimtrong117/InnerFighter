using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Die_State : FSM_State
{
    public FireBoss parent;
    public float timer;
    public float state_dur=2.13f;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.dataBiding.Die = true;
        parent.audioSource.PlayOneShot(parent.diesound);
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= state_dur)
        {
            timer = 0;
            parent.OnDieAnimEnd();
        }
    }
}
