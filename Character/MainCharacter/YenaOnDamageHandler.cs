using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenaOnDamageHandler : CharacterOnDamageHandler
{
    private void Awake()
    {

    }
    public override void OnDamge(DamageData damageData)
    {
        if (Yena.Instance.attribute.isImmune == false)
        {
            effectiveness_ratio = ElementalManager.ElementalEffectiveRatio(Yena.Instance.attribute.elemental, damageData.elemental);
            Yena.Instance.attribute.current_YingEnergy += damageData.HP_Damage * effectiveness_ratio;
            if(Yena.Instance.attribute.current_YingEnergy>=Yena.Instance.attribute.Upgraded_MaxYin)
            {
                Yena.Instance.attribute.current_YingEnergy = Yena.Instance.attribute.Upgraded_MaxYin;
                ViewManager.Instance.SwitchView(ViewIndex.DieView);
                Time.timeScale = 0;
            }
            HPdamgage = damageData.HP_Damage * effectiveness_ratio;
            PopUpDamage();
        }
    }
}
