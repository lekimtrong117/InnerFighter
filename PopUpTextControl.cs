using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUpTextControl : MonoBehaviour
{
    Canvas canvas;
    public TextMeshProUGUI textmp;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        textmp = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        
    }

    private void Update()
    {
        BillBoarding();
    }

    public void SetUp(Vector3 pos,string text,float fontsize,Color color)
    {
        transform.position = pos;
        textmp.text = text;
        textmp.fontSize= fontsize;
        textmp.color = color;
    }   
    public void OnAnimEnd()
    {
        PoolManager.Instance.DeSpawn("PopUpText", this.transform);
    }    
    private void BillBoarding()
    {
        canvas.transform.forward = Camera.main.transform.forward;
    }    
}
