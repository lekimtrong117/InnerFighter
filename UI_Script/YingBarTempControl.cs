using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YingBarTempControl : YingBarControl
{
    public override void YingBarFill()
    {
        yingbar.fillAmount = Yena.Instance.attribute.current_YingEnergy / Yena.Instance.attribute.Upgraded_MaxYin;
    }
    public override void HandleSkullNode()
    {
        
    }
}
