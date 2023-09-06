using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Stun_State : FSM_State
{
    public FireBoss parent;
    float timer;
    public float stun_eff_height;
    Transform stuneffect;
    public float stun_resist_time = 20;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.audioSource.PlayOneShot(parent.StunSound);
        parent.dataBiding.Stun = true;
        stuneffect = PrefabManager.Instance.CreateStunEffect(parent.head, stun_eff_height, parent.attribute.stun_duration);
        timer = 0;
        parent.attribute.isResistStun = true;
        IEnumerator stunresistDelay = StunResistDelay();
        ScenceManager.Instance.StartCoroutine(stunresistDelay);
    }
    public IEnumerator StunResistDelay()
    {
        yield return new WaitForSeconds(stun_resist_time);
        parent.attribute.isResistStun = false;
    }

    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer >= parent.attribute.stun_duration)
        {
            timer = 0;
            parent.GotoState(parent.previous_state);
        }
    }
    public override void Exit()
    {
        timer = 0;
        parent.attribute.isStunning = false;
        parent.attribute.currentSP = 0;
        if (stuneffect != null)
        {
            PoolManager.Instance.DeSpawn("StunEffect", stuneffect);
        }
    }

}
