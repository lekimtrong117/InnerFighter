using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreView : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float lerp_speed = 1;
    public float score;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        score = Mathf.Lerp(score, Yena.Instance.attribute.score, lerp_speed);
        tmp.text = score.ToString();
    }

}
