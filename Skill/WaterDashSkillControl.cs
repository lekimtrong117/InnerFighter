using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDashSkillControl : DashSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {
        skill_Base_HPdamage_scale = 2;
        skill_Base_SPdamage = 10f;
        skill_Base_flyspeed = 50;
        skill_Base_max_flydistance = 30;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.dash_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
        WaterSplash water_splash = PoolManager.Instance.Spawn("WaterSplash").gameObject.GetComponent<WaterSplash>();
        DamageData damageData = new DamageData { elemental = Elemental.Water, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        water_splash.SetUp(Yena.Instance.trans.position, damageData, Target_tag.Enemy, true, false);
        water_splash.StayAT_IN(Yena.Instance.trans.position, 0.2f);
    }
}
