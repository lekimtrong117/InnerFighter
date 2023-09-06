using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Ninja_Melee_State : FSM_State
{
    //drag in component
    [NonSerialized] public Ninja parent;
    //m_var
    bool melee_done = false;
    float normal_runSpeed;
    float dash_distance_counter = 0;
    Vector3 melee_target;
    float distance_to_melee_target;
    bool performing_attack = false;
    Vector3 attack_dir;
    //ninjja param
    public float Melee_runSpeed = 100;
    public float delay_time_before_attack = 1;
    public float melee_dash_distance = 5;
    IEnumerator delayMelee;


    public override void OnEnter()
    {
        base.OnEnter();
        melee_done = false;
        // prepare before attacking
        parent.audioSource.PlayOneShot(parent.melee);
        parent.animator.Play("LocoMotion", 0);
        parent.dataBiding.Run = 0;
        parent.trans.forward = parent.dirToPlayer;
        // tao dau cham than tren dau
        parent.chamThan = PoolManager.Instance.Spawn("ChamThan").gameObject;
        parent.chamThan.transform.SetParent(parent.trans);
        parent.chamThan.transform.localPosition = new Vector3(0, 3, 0);
        // chuan bi dash
        dash_distance_counter = 0;
        melee_target = parent.player.transform.position;
        attack_dir = melee_target - parent.trans.position;
        attack_dir.Normalize();
        attack_dir.y = 0;
        normal_runSpeed = parent.attribute.run_Speed;
        //delay
        if (delayMelee != null)
        {
            parent.StopCoroutine(delayMelee);
        }
        delayMelee = DelayMelee();
        parent.StartCoroutine(delayMelee);
    }
    public override void Update()
    {
        base.Update();
        if (parent.attribute.isAlive == false && parent.CurrentState != parent.die_State)
            parent.OnDeath();
        // state transit
        if (melee_done)
        {
            if (parent.shuriken_is_available == true && parent.distance_to_player <= parent.throw_Distance)
            {
                parent.GotoState(parent.throw_State);
            }
            else parent.GotoState(parent.run_State);
        }
        //melee
        if (performing_attack == true)
        {
            distance_to_melee_target = Vector3.Distance(parent.transform.position, melee_target);
            if (dash_distance_counter > melee_dash_distance)
            {
                dash_distance_counter = 0;
                parent.dataBiding.Melee = false;
                melee_done = true;
                performing_attack = false;
                parent.attribute.run_Speed = normal_runSpeed;
            }
            else
            {
                // perform dash
                parent.transform.forward = attack_dir;
                parent.moveVector3D.x = attack_dir.x;
                parent.moveVector3D.z = attack_dir.z;
                parent.HandleGravity();
                parent.characterController.Move(parent.moveVector3D * Time.deltaTime * parent.attribute.run_Speed);
                // dash distance calculate
                dash_distance_counter += parent.moveVector3D.magnitude * Time.deltaTime * parent.attribute.run_Speed;

            }
        }
    }
    public IEnumerator DelayMelee()
    {
        yield return new WaitForSeconds(delay_time_before_attack);
        PoolManager.Instance.DeSpawn("ChamThan", parent.chamThan.transform);
        if(parent.attribute.isAlive&&parent.attribute.isStunning!=true)
        parent.dataBiding.Melee = true;
        parent.attribute.run_Speed = Melee_runSpeed;
        performing_attack = true;
        parent.OnMelee();
    }
    public override void Exit()
    {
        base.Exit();
        if (delayMelee != null)
        {
            parent.StopCoroutine(delayMelee);
        }
        parent.dataBiding.Melee = false;
        if (parent.chamThan != null)
        {
            PoolManager.Instance.DeSpawn("ChamThan", parent.chamThan.transform);
        }
        performing_attack = false;
        parent.attribute.run_Speed = normal_runSpeed;
        melee_done = false;
        dash_distance_counter = 0;
    }
}
