using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyLevelIndicator : MonoBehaviour
{
    public TextMeshProUGUI texmp;
    public Canvas canvas;
    public Enemy enemy;

    private void Awake()
    {
        texmp = GetComponent<TextMeshProUGUI>();
        canvas = GetComponentInParent<Canvas>();
        enemy = canvas.gameObject.GetComponentInParent<Enemy>();
    }

    private void Start()
    {   
        SetUp();
    }
    public void SetUp()
    {
        
        texmp.text = enemy.attribute.level.ToString();
    }    

}
