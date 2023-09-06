using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class YenaUltimateControl : MonoBehaviour
{
    Transform trans;
    //drag in component
    public YenaDataBiding yenaDataBiding;
    public Transform model;
    //m_var
    MyInput myInput;

    void Awake()
    {
        trans = transform;
        //enable input
        myInput = new MyInput();
        myInput.Player.Enable();
        myInput.Player.Ultimate.performed += OnUltimateGamepad;
    }

    private void OnDestroy()
    {
        myInput.Player.Ultimate.performed -= OnUltimateGamepad;
    }

    void Update()
    {

    }
    public void OnUltimateGamepad(InputAction.CallbackContext callbackContext)
    {
            OnUltimate();
    }
    public void OnUltimate()
    {
        if (Yena.Instance.attribute.current_YangEnergy >= Yena.Instance.attribute.base_Max_YangEnergy && Yena.Instance.attribute.isUsingUltimate == false)
        {
            Yena.Instance.audioSource.PlayOneShot(Yena.Instance.ultimate_sound);
            PrefabManager.Instance.CreatePopUpText(trans.position, "LV UP", 40, Color.green);
            Yena.Instance.attribute.LevelUp();
            Yena.Instance.attribute.isUsingUltimate = true;
            yenaDataBiding.ultimate = true;
            Transform twindragon = PoolManager.Instance.Spawn("TwinDragon");
            twindragon.position = trans.position;
            twindragon.gameObject.GetComponent<TwinDragonControl>().SetUpDragon();
        }
        else
        {
            PrefabManager.Instance.CreatePopUpText(Yena.Instance.trans.position, "not available", 30, Color.white);
        } 
            
       
    }
   

}
