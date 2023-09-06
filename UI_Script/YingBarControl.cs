using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YingBarControl : MonoBehaviour
{
    public Image yingbar;
    public float lerp_spped = 1;
    public Transform skull_node;
    public GameObject red_screen;

    private void Awake()
    {
        yingbar = GetComponent<Image>();
    }

    private void Update()
    {
        YingBarFill();
        HandleSkullNode();

    }
   public virtual void YingBarFill()
    {
        yingbar.fillAmount = Mathf.Lerp(yingbar.fillAmount, Yena.Instance.attribute.current_YingEnergy / Yena.Instance.attribute.Upgraded_MaxYin, lerp_spped * Time.deltaTime);
    }
    public virtual void HandleSkullNode()
    {
        if (Yena.Instance.attribute.current_YingEnergy >= 0.8f * Yena.Instance.attribute.Upgraded_MaxYin && skull_node.gameObject.activeSelf == false)
        {
            skull_node.gameObject.SetActive(true);
            red_screen.SetActive(true);
        }
        if (Yena.Instance.attribute.current_YingEnergy < 0.7f * Yena.Instance.attribute.Upgraded_MaxYin && skull_node.gameObject.activeSelf == true)
        {
            skull_node.gameObject.SetActive(false);
            red_screen.SetActive(false);
        }
    }
}
