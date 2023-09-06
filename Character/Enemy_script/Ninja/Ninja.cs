using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RootMotion.Demos.Turret;

public class Ninja : Enemy
{
    //drag in component
    public Transform righthand;
    public Transform rightFoot;
    public AudioClip melee;
    public AudioClip die;
    //FSM state
    public Ninja_Idle_State idle_State;
    public Ninja_Run_State run_State;
    public Ninja_Throw_State throw_State;
    public Ninja_Stunned_State stunned_State;
    public Ninja_Die_State die_State;
    public Ninja_Melee_State melee_State;
    //shuriken cooldown
    public float cooldownShuriken = 5;
    [NonSerialized] public bool shuriken_is_available = true;
    //ninja param
    public float throw_Distance = 30;
    public float melee_Distance = 10;
    
    //m_var
    public override void InitEnemy()
    {
        base.InitEnemy();
        // set up fsm state
        idle_State.parent = this;
        run_State.parent = this;
        throw_State.parent = this;
        stunned_State.parent = this;
        die_State.parent = this;
        melee_State.parent = this;

    }
    public override void SetUpEnemy()
    {
        base.SetUpEnemy();
        shuriken_is_available = true;
        GotoState(idle_State);
        
    }

    public void ShurkikenCoolDownHandler()
    {
        shuriken_is_available = false;
        StopCoroutine("CorroutineShurikenCoolDown");
        StartCoroutine("CorroutineShurikenCoolDown");
    }
    public IEnumerator CorroutineShurikenCoolDown()
    {
        yield return new WaitForSeconds(cooldownShuriken);
        shuriken_is_available = true;
    }
    public override void OnStun()
    {
        base.OnStun();
        GotoState(stunned_State);
    }
    public override void OnDeath()
    {
        base.OnDeath();
        GotoState(die_State);
    }

    public virtual void OnThrow()
    {

    }
    public virtual void OnMelee()
    {


    }
 
}
