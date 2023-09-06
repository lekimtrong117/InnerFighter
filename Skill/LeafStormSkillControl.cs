using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafStormSkillControl : SpellSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {

        skill_Base_HPdamage_scale = 6 ;
        skill_Base_SPdamage =10;
        skill_Base_flyspeed = 40;
        skill_Base_max_flydistance = 40;
        skill_Base_duration = 4;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.spell_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);

        //spawn center storm
        LeafStorm leafstorm = PoolManager.Instance.Spawn("LeafStorm").gameObject.GetComponent<LeafStorm>();
        DamageData damageData = new DamageData { elemental = Elemental.Grass, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        leafstorm.SetUp(target_point, damageData, Target_tag.Enemy, false, false);
        leafstorm.StayAT_IN(target_point, skill_Base_duration);
        //spawn left storm
        leafstorm = PoolManager.Instance.Spawn("LeafStorm").gameObject.GetComponent<LeafStorm>();
        damageData = new DamageData { elemental = Elemental.Grass, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        leafstorm.SetUp(target_point, damageData, Target_tag.Enemy,false, false);
        leafstorm.StayAT_IN(target_point+new Vector3(5,0,5), skill_Base_duration);
        // spawn right storm
        leafstorm = PoolManager.Instance.Spawn("LeafStorm").gameObject.GetComponent<LeafStorm>();
        damageData = new DamageData { elemental = Elemental.Grass, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        leafstorm.SetUp(target_point, damageData, Target_tag.Enemy,false, false);
        leafstorm.StayAT_IN(target_point+new Vector3(-5,0,5), skill_Base_duration);
    }
}
