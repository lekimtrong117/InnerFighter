using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSelectionView : BaseView
{
    public void OnExitButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }    
    public void On1stButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.FireDash, SkillType.DashSkill);
        Time.timeScale = 1;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }
    public void On2ndButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.WaterDash, SkillType.DashSkill);
        Time.timeScale = 1;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }
    public void On3rdButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.GrassDash, SkillType.DashSkill);
        Time.timeScale = 1;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }
    public void On4thButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.ElectricDash, SkillType.DashSkill);
        Time.timeScale = 1;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }
    public void On5thButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Yena.Instance.skillManager.AddNewSkillForYena(SkillName.IceDash ,SkillType.DashSkill);
        Time.timeScale = 1;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }

}
