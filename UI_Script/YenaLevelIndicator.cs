using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YenaLevelIndicator : MonoBehaviour
{
    public static TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "LV 1";
    }
    public static void UpdateLevel()
    {
        tmp.text = "LV " + Yena.Instance.attribute.level;
    }    


}
