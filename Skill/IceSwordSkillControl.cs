using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSwordSkillControl : SpellSkill
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {
        skill_Base_HPdamage_scale = 3f;
        skill_Base_SPdamage = 20;
        skill_Base_flyspeed = 50;
        skill_Base_max_flydistance = 30;
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.normal_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level;
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        //
        IceSword icesword = PoolManager.Instance.Spawn("IceSword").gameObject.GetComponent<IceSword>();
        DamageData damageData = new DamageData { elemental = Elemental.Ice, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        icesword.SetUp(cast_point, damageData, Target_tag.Enemy,false, false);
        Vector3 dir_to_target = target_point - Yena.Instance.trans.position;
        dir_to_target.y = 0;
        dir_to_target.Normalize();
        icesword.StayAT_IN(Yena.Instance.trans.position + dir_to_target * 3, 0.5f);
        icesword.trans.forward = dir_to_target;
        icesword.PlaySwordAnim();
    }
}
