using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class YenaNormalAttackControl : MonoBehaviour
{
    Transform trans;
    //drag in component
    public YenaDataBiding yenaDataBiding;
    public Transform model;
    public Transform sampleTarget;
    public YenaSkillManager yenaSkillManager;
    //m_var
    MyInput myInput;
    public SkillAction onSkillcast;
    // normal attack param
    public float coolDownNormalAttack = 0.5f;
    private float timer_NormalAttack = 0;
    void Awake()
    {
        yenaSkillManager = gameObject.GetComponent<YenaSkillManager>();
        trans = transform;
        //enable input
        myInput = new MyInput();
        myInput.Player.Enable();
        myInput.Player.NormalAttack.performed += OnNormalAttackGamepad;
        // 
        timer_NormalAttack = coolDownNormalAttack;
    }
    private void OnDestroy()
    {
        myInput.Player.NormalAttack.performed -= OnNormalAttackGamepad;
    }

    void Update()
    {
        timer_NormalAttack += Time.deltaTime;
    }
    // input gamepad or keyboard event
    public void OnNormalAttackGamepad(InputAction.CallbackContext callbackContext)
    {
        NormalAttack();
    }
    // attack button event

    public void NormalAttack()
    {

        if (timer_NormalAttack >= coolDownNormalAttack)
        {
            Enemy nearestEnemy = Yena.Instance.NearestEnemy();
            timer_NormalAttack = 0;
            yenaDataBiding.normalAttack = true;
        }

    }
    public void OnNormalAttackAnim()
    {
        
        if (Yena.Instance.NearestEnemy() != null)
            onSkillcast.Invoke(Yena.Instance.leftHand.position, Yena.Instance.NearestEnemy().trans.position);
        else
            onSkillcast.Invoke(Yena.Instance.leftHand.position, this.trans.position + this.trans.forward * 10);
    }
}
