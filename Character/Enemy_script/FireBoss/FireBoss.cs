using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RootMotion.Demos.CharacterThirdPerson;
using UnityEngine.UI;

public class FireBoss : Enemy

{
    public int fly_count = 0;
    public int run_count = 0;
    //
    public FireBoss_Run_State run_state;
    public FireBoss_Ground_Charge_State ground_charge_State;
    public FireBoss_Ground_FastRun_State ground_fastRun_State;
    public FireBoss_Ground_Shoot_State ground_shoot_state;
    public FireBoss_Ground_Melee_State ground_melee_state;
    public FireBoss_Fly_FireDash_State fly_dash_state;
    public FireBoss_Fly_FireDrop_State fly_fire_drop_state;
    public FireBoss_Fly_Landing_State Fly_Landing_State;
    public FireBoss_Fly_State fly_State;
    public FireBoss_Stun_State stun_state;
    public FireBoss_Die_State die_state;
    public Fire_Boss_Idle_State idle_state;
    // 
    public List<FSM_State> run_next_state;
    public List<FSM_State> fly_next_state;
    // 
    public Transform telering;
    public Transform head;
    //sound
    public AudioClip idlesound;
    public AudioClip runsound;
    public AudioClip shootSound;
    public AudioClip charge_sound;
    public AudioClip flysound;
    public AudioClip diesound;
    public AudioClip bitesound;
    public AudioClip StunSound;
    public float dialog_height = 20;
    public override void InitEnemy()
    {
        base.InitEnemy();
        run_state.parent = this;
        ground_charge_State.parent = this;
        ground_fastRun_State.parent = this;
        ground_shoot_state.parent = this;
        ground_melee_state.parent = this;
        fly_dash_state.parent = this;
        fly_fire_drop_state.parent = this;
        Fly_Landing_State.parent = this;
        fly_State.parent = this;
        stun_state.parent = this;
        die_state.parent = this;
        idle_state.parent = this;
     }


public override void SetUpEnemy()
{
    base.SetUpEnemy();
    run_next_state = new List<FSM_State>();
    fly_next_state = new List<FSM_State>();
    run_next_state.Add(ground_shoot_state);
    run_next_state.Add(ground_charge_State);
    run_next_state.Add(ground_fastRun_State);
    fly_next_state.Add(fly_dash_state);
    fly_next_state.Add(fly_fire_drop_state);
    fly_next_state.Add(Fly_Landing_State);
        EnemySpawnManager.Instance.max_enemy_in_battleground = 2;
    GotoState(idle_state);
}
public override void OnStun()
{
    base.OnStun();
    GotoState(stun_state);
}
public override void OnDeath()
{
    base.OnDeath();
        EnemySpawnManager.Instance.max_enemy_in_battleground = 4;
        GotoState(die_state);
        MusicManager.Instance.audioSource.clip = MusicManager.Instance.music1;
        MusicManager.Instance.audioSource.Play();
    } 
}
