using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttributeControl : CharacterAttributeControl
{
    public float Base_essen;
    public float Upgraded_Essen;
    public bool isAlive;
    public bool isStunning = false;
    public float currentHP;
    public float base_MAX_HP;
    public float upgraded_MAX_HP;
    public float base_MAX_SP;
    public float upgraded_max_SP;
    public float currentSP;
    public float current_Attack = 10;
    public float upgraded_Attack = 10;
    public float base_Attack = 10;
    public static float increase_percent_per_level = 0.1f;
    public float run_Speed = 10;
    public float stun_duration = 2f;
    public bool canbePush;
    public bool isBlocking;
    public bool isResistStun;
    public bool bounty;
    Enemy enemy;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        
    }
    private void FixedUpdate()
    {
        
    }
    public void SetUpAttribute()
    {
        //level calculate
        upgraded_MAX_HP = base_MAX_HP + base_MAX_HP * (level - 1) * increase_percent_per_level;
        upgraded_max_SP = base_MAX_SP + base_MAX_SP * (level - 1) * increase_percent_per_level;
        upgraded_Attack = base_Attack + base_Attack * (level - 1) * increase_percent_per_level;
        Upgraded_Essen = Base_essen + Base_essen * (level - 1) * increase_percent_per_level;
        //
        currentHP = upgraded_MAX_HP;
        currentSP = 0;
        current_Attack = upgraded_Attack;
        isAlive = true;
        isStunning = false;
        EnemyLevelIndicator levelIndicator=GetComponentInChildren<Canvas>().gameObject.GetComponentInChildren<EnemyLevelIndicator>();
        if(levelIndicator != null)
        levelIndicator.SetUp();
      EnemyElementalIndicator EleIndicator = GetComponentInChildren<Canvas>().gameObject.GetComponentInChildren<EnemyElementalIndicator>();
        if (EleIndicator != null)
            EleIndicator.SetUpElemenIndicator();
        canbePush = true;
        isBlocking=false;
        isResistStun = false;
        bounty = false;
    }
}
