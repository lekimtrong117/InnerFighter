using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpinView : BaseView
{
    public SpinWheel wheel;
    public GameObject pointer;
    public bool spinAvailable;
    IEnumerator delay;
    public Action spincallback;
    IEnumerator spin_coroutin;
    public AudioClip clip_before_spin;
    public void Start()
    {
        wheel = new SpinWheel(8);
        wheel.setWheel(pointer);
        wheel.AddCallback(OnSpinDone);
    }
    public override void Setup(ViewParam viewParam)
    {
        base.Setup(viewParam);
        spinAvailable = true;
        clip_before_spin = MusicManager.Instance.audioSource.clip;
        MusicManager.Instance.PlayMusic(MusicManager.Instance.spin);
    }
    public void OnSpinButton()
    {
        if (spinAvailable)
        {
            spinAvailable = false;
            if (spin_coroutin != null)
                StopCoroutine(spin_coroutin);
            spin_coroutin = wheel.StartNewRun();
            StartCoroutine(spin_coroutin);
            
        }
    }
    public void OnSpinDone(int result)
    {
        switch (result)
        {
            case 1:
                {
                    
                    spincallback = Spell1;
                    SpinViewDissapear();
                    break;

                }
            case 2:
                {
                    
                    spincallback = Spell2;
                    SpinViewDissapear();
                    break;
                }
            case 3:
                {
                    
                    spincallback = Dash1;
                    SpinViewDissapear();
                    break;
                }
            case 4:
                {
                    
                    spincallback = Dash2;
                    SpinViewDissapear();
                    break;
                }

            case 5:
                {
                    
                    spincallback = Stun;
                    SpinViewDissapear();
                    break;
                }
            case 6:
                {
                   ;
                    spincallback = AllSkil;
                    SpinViewDissapear();
                    break;
                }
            case 7:
                {
               
                    spincallback = Normal1;
                    SpinViewDissapear();
                    break;
                }
            case 8:
                {
                
                    spincallback = Normal2;
                    SpinViewDissapear();
                    break;
                }
            default:
                {
                 
                    spincallback = AllSkil;
                    SpinViewDissapear();
                    break;
                }
        }
    }
    public void SpinViewDissapear()
    {
        if (delay != null)
        {
            StopCoroutine(delay);
        }
        delay = Delay();
        StartCoroutine(delay);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3);
        MusicManager.Instance.PlayMusic(clip_before_spin);
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView, null, spincallback);

    }
    public void Spell1()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.spell_skill_level += 1;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "Spell LV " + Yena.Instance.attribute.spell_skill_level, 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void Spell2()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.spell_skill_level += 2;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "Spell LV " + Yena.Instance.attribute.spell_skill_level, 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void Dash1()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.dash_skill_level += 1;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "Dash LV " + Yena.Instance.attribute.dash_skill_level, 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void Dash2()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.dash_skill_level += 2;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "Dash LV " + Yena.Instance.attribute.dash_skill_level, 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void Stun()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.spell_stun_multiply += 0.2f;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "STUN " + Yena.Instance.attribute.spell_stun_multiply * 100 + "%", 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void AllSkil()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.dash_skill_level += 1;
        Yena.Instance.attribute.normal_skill_level += 1;
        Yena.Instance.attribute.spell_skill_level += 1;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "All Skill +1LV", 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void Normal1()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.normal_skill_level += 1;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "Normal LV " + Yena.Instance.attribute.normal_skill_level, 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
    public void Normal2()
    {
        Time.timeScale = 1;
        Yena.Instance.attribute.normal_skill_level += 2;
        PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "Normal LV " + Yena.Instance.attribute.normal_skill_level, 30, Color.green);
        Yena.Instance.attribute.isUsingUltimate = false;
    }
}
