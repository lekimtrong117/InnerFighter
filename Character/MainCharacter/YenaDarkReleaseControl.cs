using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class YenaDarkReleaseControl : MonoBehaviour
{
    Transform trans;
    //drag in component
    public YenaDataBiding yenaDataBiding;
    public Transform model;
    //m_var
    MyInput myInput;
    float total_yang;
    int essen_count;
    public float dark_release_damgeScale = 2;
    public float yingyang_ratio = 5;
    void Awake()
    {
        trans = transform;
        //enable input
        myInput = new MyInput();
        myInput.Player.Enable();
        myInput.Player.DarkRelease.performed += OnDarkReleaseGamepad;
    }

    private void OnDestroy()
    {
        myInput.Player.DarkRelease.performed -= OnDarkReleaseGamepad;
    }

    void Update()
    {
    }
    public void OnDarkReleaseGamepad(InputAction.CallbackContext callbackContext)
    {
        OnDarkRelease();
    }
    public void OnDarkRelease()
    {
        total_yang = 0;
        essen_count = 0;
        Yena.Instance.dataBiding.DarkRelease = true;
        YangEssen[] essens = GameObject.FindObjectsOfType<YangEssen>();
        if (essens.Length != 0)
        {
            foreach (YangEssen essen in essens)
            {
                essen_count++;
                total_yang += essen.damageData.HP_Damage;
                essen.FlyTo(Yena.Instance.trans.position, 1, 1);// alwway fly to yena in 0.5f, see YangEssn script
            }
            Yena.Instance.attribute.current_YingEnergy -= total_yang / yingyang_ratio;
            if (Yena.Instance.attribute.current_YingEnergy < 0)
                Yena.Instance.attribute.current_YingEnergy = 0;
            //play sound
            Yena.Instance.audioSource.PlayOneShot(Yena.Instance.darkrelease_sound);
            //damgae calculate
            DamageData dam = new DamageData();
            dam.HP_Damage = total_yang/3;
            dam.SP_Damage = 0;
            dam.elemental = Elemental.Dark;
            var darkrelease = PrefabManager.Instance.CreateProjectile("DarkRelease", this.trans.position, dam, Target_tag.Enemy, true, false);
            darkrelease.StayAT_IN(darkrelease.trans.position, 5);
            PrefabManager.Instance.CreatePopUpText(trans.position, "YIN UNLEASHED", 20, Color.black);
        }
        else
        {
            PrefabManager.Instance.CreatePopUpText(trans.position, "No Yang Essen To Consume", 20, Color.gray);
        }
    }
}
