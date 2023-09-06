using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Ground_Melee_State : FSM_State
{
    public FireBoss parent;

    float timer_state = 0;
    float timer_bite = 0;
    public DamageData damage = new DamageData();
    public float state_dur = 3.6f;
    public float melee_hit_rate = 1.167f;
    bool Isrunning;
    public float teleport_pos = 5;
    IEnumerator delayring;
    public float melee_damge_scale = 4;
    public float hit_range = 4;
    public override void OnEnter()
    {
        base.OnEnter();
        //
        PrefabManager.Instance.CreateNPCDialog(parent.trans, new Vector3(0, parent.dialog_height, 5), "stop running", 10, Color.red, 3);
        timer_bite = 0;
        timer_state = 0;
        //
        parent.trans.forward = parent.dirToPlayer;
        parent.dataBiding.Melee = true;
        //teleport
        parent.characterController.enabled = false;
        parent.trans.position = parent.player.transform.position + new Vector3(0, 0, teleport_pos);
        parent.characterController.enabled = true;
        parent.telering.gameObject.SetActive(true);
        delayring = DelayRing();
        ScenceManager.Instance.StartCoroutine(delayring);
    }
    public override void Update()
    {
        base.Update();
        parent.trans.forward = parent.dirToPlayer;
        timer_bite += Time.deltaTime;
        timer_state += Time.deltaTime;
        if (timer_bite >= melee_hit_rate)
        {
            parent.audioSource.PlayOneShot(parent.bitesound);
            timer_bite = 0;
            damage.HP_Damage = melee_damge_scale * parent.attribute.current_Attack;
            damage.SP_Damage = 10;
            damage.elemental = Elemental.Fire;
            Collider[] cols = Physics.OverlapSphere(parent.head.position, hit_range, parent.playermask);
            if (cols != null)
            {
                foreach (Collider col in cols)
                {
                    col.gameObject.GetComponent<YenaOnDamageHandler>().OnDamge(damage);
                }
            }
            parent.characterController.enabled = false;
            parent.trans.position = parent.player.transform.position + new Vector3(0, 0, teleport_pos);
            parent.characterController.enabled = true;
            parent.telering.gameObject.SetActive(true);
            delayring = DelayRing();
            ScenceManager.Instance.StartCoroutine(delayring);
        }
        if (timer_state >= state_dur)
        {
            timer_state = 0;
            parent.GotoState(parent.run_state);
        }
    }
    public IEnumerator DelayRing()
    {
        yield return new WaitForSeconds(1);
        parent.telering.gameObject.SetActive(false);
    }
}
