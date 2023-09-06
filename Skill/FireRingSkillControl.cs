using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class FireRingSkillControl : SkillControl
{
    private void Awake()
    {
        SkillSetUp();
    }
    public override void SkillSetUp()
    {
        skill_Base_duration = 3;
        skill_Base_HPdamage_scale = 2.67f* Projectile.stay_damgae_rate;
        skill_Base_SPdamage = 6.67f* Projectile.stay_damgae_rate;
        skill_Base_flyspeed = 40;
        skill_Base_max_flydistance = 40;
        
    }
    public override void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {
        // HP damage calculate
        int skill_level = Yena.Instance.attribute.spell_skill_level;////// THIS CODE IS DIFFERENT FOR EACH SKILL
        float yena_currentATK = Yena.Instance.attribute.current_Attack;
        float increase_per_level = Yena.Instance.attribute.increase_per_skill_level; 
        float HP_damage = yena_currentATK * skill_Base_HPdamage_scale * (1 + (skill_level - 1) * increase_per_level);
        FireRing fireRing = PoolManager.Instance.Spawn("FireRing").gameObject.GetComponent<FireRing>();
        DamageData damageData = new DamageData { elemental = Elemental.Fire, HP_Damage = HP_damage, SP_Damage = skill_Base_SPdamage * Yena.Instance.attribute.spell_stun_multiply };
        fireRing.SetUp(target_point, damageData, Target_tag.Enemy,false, false);
        fireRing.StayAT_INandDealStayDamage(target_point, skill_Base_duration);
    }

}
