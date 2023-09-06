using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YangBarTempControl : YangBarControl
{
    public override void YangBarFill()
    {
        yangbar.fillAmount = Yena.Instance.attribute.current_YangEnergy / Yena.Instance.attribute.base_Max_YangEnergy;
    }
}

