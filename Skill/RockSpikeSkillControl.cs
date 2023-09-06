using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpikeSkillControl : NormalSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {

        skill_Base_HPdamage_scale = 0.5f;
        skill_Base_SPdamage = 10f;
        skill_Base_flyspeed = 5;
        skill_Base_max_flydistance = 5;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.normal_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
        RockSpike rockspike = PoolManager.Instance.Spawn("RockSpike").gameObject.GetComponent<RockSpike>();
        DamageData damageData = new DamageData { elemental = Elemental.Grass, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        //rock spawn at near to enemy
        Vector3 dir_to_enemy = target_point - Yena.Instance.trans.position;
        Vector3 rock_spawn_point = target_point - dir_to_enemy.normalized * 2;
        rockspike.SetUp(rock_spawn_point, damageData, Target_tag.Enemy,false, false);
        rockspike.FlyTo(target_point, skill_Base_flyspeed, skill_Base_max_flydistance);
    }
}
