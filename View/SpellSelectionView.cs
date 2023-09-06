using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelectionView : BaseView
{
  
    public void On1stButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.FireRing, SkillType.spellAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.DashSelectionView);
    }
    public void On2ndButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.WaterBall, SkillType.spellAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.DashSelectionView);
    }
    public void On3rdButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.LeafStorm, SkillType.spellAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.DashSelectionView);
    }
    public void On4thButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.Thunder, SkillType.spellAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.DashSelectionView);
    }
    public void On5thButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.IceHammer, SkillType.spellAttackSkill);
        ViewManager.Instance.SwitchView(ViewIndex.DashSelectionView);
    }

}
