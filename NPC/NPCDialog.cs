using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    Canvas canvas;
    public TextMeshProUGUI textmp;
    IEnumerator delay;
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

    public void SetUp(Transform parent, Vector3 local_pos, string text, float fontsize, Color color, float dur)
    {
        transform.SetParent(parent);
        transform.localPosition = local_pos;
        textmp.text = text;
        textmp.fontSize = fontsize;
        textmp.color = color;
        if(delay!=null)
        {
            StopCoroutine(delay);
        }
        delay = Delay(dur);
        StartCoroutine(delay);
    }
    IEnumerator Delay(float dur)
    {
        yield return new WaitForSeconds(dur);
        PoolManager.Instance.DeSpawn("NPCDialog", this.transform);
    }
    private void BillBoarding()
    {
        canvas.transform.forward = Camera.main.transform.forward;
    }
}
