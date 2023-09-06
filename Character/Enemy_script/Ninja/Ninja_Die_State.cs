using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Ninja_Die_State :FSM_State
{
    float timer;
   [NonSerialized] public Ninja parent;
    public float state_dur = 2.5f;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.die);
        parent.dataBiding.Die = true;
        timer = 0;
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if(timer >=state_dur)
        {
            timer = 0;
            parent.OnDieAnimEnd();
        }
    }
}
