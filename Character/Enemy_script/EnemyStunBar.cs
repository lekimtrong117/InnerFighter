using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class EnemyStunBar : MonoBehaviour
{
    [NonSerialized] public Slider slider;
    public Vector3 offset;
    public Quaternion rotationOffset;
    public Transform maincam;
    public Canvas canvas;
    public Transform character;
    [NonSerialized] Enemy enemy;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        maincam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        canvas = GetComponentInParent<Canvas>();
        canvas.worldCamera = Camera.main;
        enemy = canvas.gameObject.GetComponentInParent<Enemy>();
        character = canvas.gameObject.GetComponentInParent<CharacterAttributeControl>().transform;
        AdjustBarTransformOnWorldView();
    }

    private void Update()
    {
        AdjustBarTransformOnWorldView();
        SliderFill();
    }
    public void AdjustBarTransformOnWorldView()
    {
        canvas.transform.forward = Camera.main.transform.forward;
    }
    public void SliderFill()
    {
        slider.value = enemy.attribute.currentSP / enemy.attribute.upgraded_max_SP;
    }
}


