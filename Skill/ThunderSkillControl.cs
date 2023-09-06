using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSkillControl : SpellSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {
        skill_Base_HPdamage_scale = 5;
        skill_Base_SPdamage = 80 ;
        skill_Base_flyspeed = 50;
        skill_Base_max_flydistance = 30;//
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.spell_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
        Thunder thunder = PoolManager.Instance.Spawn("Thunder").gameObject.GetComponent<Thunder>();
        DamageData damageData = new DamageData { elemental = Elemental.Electric, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        thunder.SetUp(Yena.Instance.trans.position, damageData, Target_tag.Enemy, true, false);
        thunder.StayAT_IN(target_point,0.5f);
    }
}
