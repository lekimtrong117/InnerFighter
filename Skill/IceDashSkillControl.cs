using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDashSkillControl : DashSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {

        skill_Base_HPdamage_scale = 2f;
        skill_Base_SPdamage = 10;
        skill_Base_flyspeed = 30;
        skill_Base_max_flydistance = 5;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    { 
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.dash_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
        IceLance icelance = PoolManager.Instance.Spawn("IceLance").gameObject.GetComponent<IceLance>();
        DamageData damageData = new DamageData { elemental = Elemental.Ice, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        //find enemy back
        Vector3 drag_dir = cast_point-target_point;
        drag_dir.y = 0;
        drag_dir.Normalize();
        Vector3 start_to_drag_pos = target_point - drag_dir * 5 + new Vector3(0, 1, 0);
        icelance.SetUp(start_to_drag_pos, damageData, Target_tag.Enemy, true, false);
        icelance.FlyTo(cast_point, skill_Base_flyspeed, skill_Base_max_flydistance);
    }
}
