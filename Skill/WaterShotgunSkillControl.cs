using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShotgunSkillControl : NormalSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {

        skill_Base_HPdamage_scale = 1.25f;
        skill_Base_SPdamage = 10;
        skill_Base_flyspeed = 30;
        skill_Base_max_flydistance = 10;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {  // with fire dash skill,target point is a point that is infront of yena, not nearest enemy

        // HP damage calculate
        int skill_level = Yena.Instance.attribute.normal_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
        for (int i = 0; i < 3; i++)
        {
            SmallWaterSplash waterSplash = PoolManager.Instance.Spawn("SmallWaterSplash").gameObject.GetComponent<SmallWaterSplash>();
            DamageData damageData = new DamageData { elemental = Elemental.Water, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
            
            Vector3 move_dir = target_point-cast_point;
            move_dir.Normalize();
            move_dir.y = 0;
            var q = Quaternion.Euler(0,-40+40*i, 0);
            Vector3 dash_point = Yena.Instance.transform.position + q * move_dir * 10;
            waterSplash.SetUp(cast_point, damageData, Target_tag.Enemy, true, false);
            waterSplash.FlyTo(dash_point, skill_Base_flyspeed, skill_Base_max_flydistance);
        }
    }

}
