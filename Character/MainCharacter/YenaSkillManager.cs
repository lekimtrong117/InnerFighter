using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenaSkillManager :MonoBehaviour
{ // drag in component
    public SkillControl currentNormalAttackSkill;
    public SkillControl currentSpellAttackSkill;
    public SkillControl currentDashSkill;

    public YenaNormalAttackControl  yenaNormalAttackControl;
    public YenaSpellAttackControl   yenaSpellAttackControl;
    public YenaDashControl          yenaDashControl;
    // m_var
    private void Awake()
    {
        //initial
        yenaNormalAttackControl = gameObject.GetComponent<YenaNormalAttackControl>();
        yenaSpellAttackControl  = gameObject.GetComponent<YenaSpellAttackControl>();
        yenaDashControl         = gameObject.GetComponent<YenaDashControl>();
        // get normal skill, spell skill. Dash skill
        AddNewSkillForYena(SkillName.IceSword, SkillType.normalAttackSkill);
        AddNewSkillForYena(SkillName.IceHammer, SkillType.spellAttackSkill);
        AddNewSkillForYena(SkillName.FireDash, SkillType.DashSkill);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        
    }
    public void AddNewSkillForYena(SkillName skillName, SkillType skillType)
    {

        switch (skillType)
        {
            case SkillType.normalAttackSkill:
                {
                    if (currentNormalAttackSkill != null)
                    {
                        Destroy(currentNormalAttackSkill);
                    }
                    currentNormalAttackSkill = GetSkillComponent(skillName);
                   // currentNormalAttackSkill.SkillSetUp();
                    yenaNormalAttackControl.onSkillcast = currentNormalAttackSkill.OnSkillCast;
                    break;
                }
            case SkillType.spellAttackSkill:
                {
                    if (currentSpellAttackSkill != null)
                    {
                         Destroy(currentSpellAttackSkill);
                    }
                    currentSpellAttackSkill = GetSkillComponent(skillName);
                   // currentSpellAttackSkill.SkillSetUp();
                  yenaSpellAttackControl.onSkillcast = currentSpellAttackSkill.OnSkillCast;
                    break;
                }
            case (SkillType.DashSkill):
                {
                    if (currentDashSkill != null)
                    {
                        Destroy(currentDashSkill);
                    }
                    currentDashSkill = GetSkillComponent(skillName);
                   // currentDashSkill.SkillSetUp();
                   yenaDashControl.onSkillcast = currentDashSkill.OnSkillCast;
                    break;
                }
        }

    }
    public SkillControl GetSkillComponent(SkillName skillname)
    {
        switch (skillname)
        {
            case SkillName.FireBall:
                {
                    return gameObject.AddComponent<FireBallSkillControl>();
                }
            case SkillName.FireRing:
                {
                    return gameObject.AddComponent<FireRingSkillControl>();
                }
            case SkillName.FireDash:
                {
                    return gameObject.AddComponent<FireDashSkillControl>();
                }
            case SkillName.WaterShotgun:
                {
                    return gameObject.AddComponent<WaterShotgunSkillControl>();
                }
            case SkillName.WaterDash:
                {
                    return gameObject.AddComponent<WaterDashSkillControl>();
                }
            case SkillName.WaterBall:
                {
                    return gameObject.AddComponent<WaterBallSkillControl>();
                }
            case SkillName.RockSpike:
                {
                    return gameObject.AddComponent<RockSpikeSkillControl>();
                }
            case SkillName.GrassDash:
                {
                    return gameObject.AddComponent<GrassDashSKillControl>();
                }
            case SkillName.LeafStorm:
                {
                    return gameObject.AddComponent<LeafStormSkillControl>();
                }
            case SkillName.ElectricBall:
                {
                    return gameObject.AddComponent<ElectricBallSkillControl>();
                }
            case SkillName.ElectricDash:
                {
                    return gameObject.AddComponent<ElectricDashSkillControl>();
                }
            case SkillName.Thunder:
                {
                    return gameObject.AddComponent<ThunderSkillControl>();
                }
            case SkillName.IceHammer:
                {
                    return gameObject.AddComponent<IceHammerSkillControl>();
                }
            case SkillName.IceDash:
                {
                    return gameObject.AddComponent<IceDashSkillControl>();
                }
            case SkillName.IceSword:
                {
                    return gameObject.AddComponent<IceSwordSkillControl>();
                }
            default:
                return null;
        }
    }
}


