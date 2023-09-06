using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class YenaSpellAttackControl : MonoBehaviour
{
    Transform trans;
    //drag in component
    public YenaDataBiding yenaDataBiding;
    public Transform model;
    public YenaSkillManager yenaStatusControl;
    Transform yenaLeftHand;
    [NonSerialized] YenaAttributeControl attribute;
    //m_var
    public SkillAction onSkillcast;
    public float timer = 0;
    //input
    MyInput myInput;
    void Awake()
    {
        attribute = gameObject.GetComponent<YenaAttributeControl>();
        yenaStatusControl = gameObject.GetComponent<YenaSkillManager>();
        trans = transform;
        //enable input

        myInput = new MyInput();
        myInput.Player.Enable();
        myInput.Player.SpellAttack.performed += OnSpellAttackGamepad;

    }

    private void OnDestroy()
    {
        myInput.Player.SpellAttack.performed -= OnSpellAttackGamepad;
    }

    private void Start()
    {
        timer = Yena.Instance.attribute.spell_attack_cooldown;
    }
    void Update()
    {
        timer += Time.deltaTime;

    }
    public void OnSpellAttackGamepad(InputAction.CallbackContext callbackContext)
    {
        OnSpellAttack();
    }
    public void OnSpellAttack()
    {
        if (timer >= Yena.Instance.attribute.spell_attack_cooldown)
        {
            timer = 0;
            yenaDataBiding.spellAttack = true;
        }
    }
    public void OnSpellAttackAnim()
    {
        if (Yena.Instance.NearestEnemy() != null)
        {
            onSkillcast.Invoke(Yena.Instance.leftHand.position, Yena.Instance.NearestEnemy().trans.position);
        }
        else
        {
            onSkillcast.Invoke(Yena.Instance.leftHand.position, trans.position + trans.forward * 10);//in casse there is no enemy around
        }
    }

}
