using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricDashSkillControl : DashSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {

        skill_Base_HPdamage_scale = 2;
        skill_Base_SPdamage = 40;
        skill_Base_flyspeed = 15;
        skill_Base_max_flydistance = 40;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {  // with fire dash skill,target point is a point that is infront of yena, not nearest enemy

        // HP damage calculate
        int skill_level = Yena.Instance.attribute.dash_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
            ElectricBall electric_ball = PoolManager.Instance.Spawn("ElectricBall").gameObject.GetComponent<ElectricBall>();
            DamageData damageData = new DamageData { elemental = Elemental.Electric, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
            electric_ball.SetUp(cast_point+new Vector3(0,1,0), damageData, Target_tag.Enemy, true, false);
            electric_ball.FlyTo(target_point, skill_Base_flyspeed, skill_Base_max_flydistance);
    }


}
