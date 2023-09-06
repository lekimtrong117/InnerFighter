using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSelectionView : BaseView
{

    public void On1stButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.FireBall, SkillType.normalAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.SpellSelectionView);
    }
    public void On2ndButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.WaterShotgun, SkillType.normalAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.SpellSelectionView);
    }
    public void On3rdButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.RockSpike, SkillType.normalAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.SpellSelectionView);
    }
    public void On4thButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.ElectricBall, SkillType.normalAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.SpellSelectionView);
    }
    public void On5thButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.IceSword, SkillType.normalAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.SpellSelectionView);
    }
}
