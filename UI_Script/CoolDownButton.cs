using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownButton : MonoBehaviour
{
    public float timer = 0;
    public float cooldown = 5;
    public Image image;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        SetUpButton();
    }

    private void Update()
    {
        cooldown = Yena.Instance.attribute.spell_attack_cooldown;
        timer = Yena.Instance.SpellAttack.timer;    
        image.fillAmount = timer / cooldown;
    }
    public void SetUpButton()
    {
        cooldown = Yena.Instance.attribute.spell_attack_cooldown;
    }    
}
