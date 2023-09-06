using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YangBarControl : MonoBehaviour
{

    public Image yangbar;
    public float lerp_spped = 1;
    private void Awake()
    {
        yangbar = GetComponent<Image>();
    }

    private void Update()
    {
        YangBarFill(); 
    }
  public virtual void YangBarFill()
    {
        yangbar.fillAmount = Mathf.Lerp(yangbar.fillAmount, Yena.Instance.attribute.current_YangEnergy / Yena.Instance.attribute.base_Max_YangEnergy, Time.deltaTime * lerp_spped) ;
    }
}
