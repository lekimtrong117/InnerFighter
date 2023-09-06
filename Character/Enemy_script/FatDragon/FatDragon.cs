using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RootMotion.Demos.Turret;

public class FatDragon : Enemy
{
    public FatDragon_Fly_State fly_state;
    public FatDragon_Shoot_State shoot_state;
    public FatDragon_Die_State die_State;
    public FatDragon_StunState stunState;
    public int fly_count;
    public int shoot_count;
    public AudioClip fly;
    public AudioClip shoot;
    public AudioClip die;
    public override void InitEnemy()
    {
        base.InitEnemy();
        // set up fsm state
        fly_state.parent = this;
        shoot_state.parent = this;
        die_State.parent = this;
        stunState.parent = this;
    }
    public override void Update()
    {
        base.Update();
        if (attribute.currentHP <= 0 && CurrentState != die_State)
            GotoState(die_State);
    }
    public override void SetUpEnemy()
    {
        base.SetUpEnemy();
        fly_count = 0;
        shoot_count = 0;
        GotoState(fly_state);
    }
    public override void OnStun()
    {
        base.OnStun();
        GotoState(stunState);

    }
    public override void OnDeath()
    {
        base.OnDeath();
        GotoState(die_State);
    }
    public virtual void OnShoot()
    {

    }
}
