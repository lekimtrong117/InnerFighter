using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateButon : MonoBehaviour
{
    public GameObject vfx;
    public void OnUltimate()
    {
            Yena.Instance.ultimate.OnUltimate();
    }
    public void Update()
    {
        if(Yena.Instance.attribute.current_YangEnergy >= Yena.Instance.attribute.base_Max_YangEnergy&&vfx.activeSelf==false)
        {
            vfx.SetActive(true);
        }
        if (Yena.Instance.attribute.current_YangEnergy < Yena.Instance.attribute.base_Max_YangEnergy && vfx.activeSelf == true)
        {
            vfx.SetActive(false);
        }
    }
}
