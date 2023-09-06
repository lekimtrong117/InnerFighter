using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YenaAttributeControl : CharacterAttributeControl
{
    // run speed
    public float current_RunSpeed;
    public float base_runSpeed = 7;
    public float upgraded_runSpeed = 7;
    // yang %
    public float current_YangEnergy = 0;
    public float base_Max_YangEnergy = 1000;
    public static float yang_increase_per_level = 500;
    //ying %
    public float current_YingEnergy = 0;
    public float Base_Max_Yin = 400;
    public float Upgraded_MaxYin = 400;
    // attack
    public float current_Attack;
    public float upgraded_Attack = 10;
    public float base_Attack = 10;
    public float attackpercent_increase_per_forcus = 0.05f;
    //level
    public float base_EXP = 1000;
    public float EXP_IncreasePerLevel = 1000;
    public float requireEXP_for_next_level = 1000;
    public static float stat_increase_per_level = 0.1f;
    //stat
    public int focus;
    public int lucid;
    public int creative;
    public int endurance;
    //purchase
    public bool seccondChance;
    public bool lastChance;
    public bool anOptimist;
    public bool burden;
    public bool anythingElse;
    public bool innerRunner;
    public bool UltraUltimate;
    // card upgrade
    public float spell_speed_multiply = 1;
    public float spell_stun_multiply = 1;
    public float spell_attack_cooldown = 3f;
    public float push_bacK_multiply = 1;
    //skill
    public int normal_skill_level;
    public int spell_skill_level;
    public int dash_skill_level;
    public float increase_per_skill_level = 0.1f;
    //status
    public bool isUsingUltimate;
    private bool _isDashimmune;
    public float score;
    public bool IsDashImmune
    {
        get
        {
            return _isDashimmune;
        }
        set
        {
       
            if (value)
            {
                Yena.Instance.shield.gameObject.SetActive(true);
                _isDashimmune = value;
            }
            else
            {
                Yena.Instance.shield.gameObject.SetActive(false);
                _isDashimmune = false;
            }
        }
    }
    public bool canDeflect
    {
        get
        {
            return _isDashimmune;
        }
    }
    public bool isImmune
    {
        get
        {
            if (IsDashImmune == true || isUsingUltimate == true)
                return true;
            else
                return false;
        }
    }

    public bool IsMoveAble
    {
        get
        {
            if (isUsingUltimate == true)
                return false;
            else return true;
        }
    }
    //
    //
    //
    //
    private void Start()
    {
        StopCoroutine("SetUpYenaAttribute");
        StartCoroutine("SetUpYenaAttribute");
    }
    public IEnumerator SetUpYenaAttribute()
    {
        // only process after Inite Data Done
        yield return new WaitUntil(() => DataAPIController.Instance.dataInitDone);
        // get stat
        focus = DataAPIController.Instance.ReadFocus();
        creative = DataAPIController.Instance.ReadCreative();
        lucid = DataAPIController.Instance.ReadLucid();
        endurance = DataAPIController.Instance.ReadEndurance();
        elemental = DataAPIController.Instance.ReadElemental();
        //get perchase upgrade
        seccondChance = DataAPIController.Instance.ReadSecondChance();
        lastChance = DataAPIController.Instance.ReadLastChance();
        anOptimist = DataAPIController.Instance.ReadAnOptimist();
        burden = DataAPIController.Instance.ReadBurden();
        innerRunner = DataAPIController.Instance.ReadInnerRunner();
        UltraUltimate = DataAPIController.Instance.ReadUltraUltimate();
        //level
        level = DataAPIController.Instance.ReadLevel();//current EXP manage by gamee manager
        requireEXP_for_next_level = base_EXP + EXP_IncreasePerLevel * (level - 1);
        //yang
        current_YangEnergy = 0;
        //ying
        current_YingEnergy = 0;
        Upgraded_MaxYin = Base_Max_Yin;
        // runspeed
        if (innerRunner)
        {
            upgraded_runSpeed = 1.2f * base_runSpeed;
        }
        else upgraded_runSpeed = base_runSpeed;
        current_RunSpeed = upgraded_runSpeed;
        //attack
        upgraded_Attack = base_Attack + focus * attackpercent_increase_per_forcus;
        current_Attack = upgraded_Attack;
        //status
        IsDashImmune = false;
        isUsingUltimate = false;
        //skill
        normal_skill_level = 1;
        spell_skill_level = 1;
        dash_skill_level = 1;
        //
        score = 0;
    }
    public void LevelUp()
    {
        level++;
        base_Max_YangEnergy += yang_increase_per_level;
        upgraded_Attack = base_Attack + stat_increase_per_level * (level - 1) * base_Attack;
        current_Attack = upgraded_Attack;
        Upgraded_MaxYin = Base_Max_Yin + stat_increase_per_level * (level - 1) * Base_Max_Yin;
        YenaLevelIndicator.UpdateLevel();
        PrefabManager.Instance.CreatePopUpText(transform.position + new Vector3(0, 1, 0), "ATK +10%", 20, Color.red);
        PrefabManager.Instance.CreatePopUpText(transform.position + new Vector3(0, 2f, 0), "Yin +10%", 20, Color.black);
    }    
    public void GainYangEnergy(float damageDealToEnemy)
    {
        current_YangEnergy += damageDealToEnemy;
    }
}

