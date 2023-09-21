using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(YenaAttributeControl))]
[RequireComponent(typeof(YenaDataBiding))]
[RequireComponent(typeof(YenaSkillManager))]
[RequireComponent(typeof(YenaMoveController))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(YenaNormalAttackControl))]
[RequireComponent(typeof(YenaSpellAttackControl))]
[RequireComponent(typeof(YenaDashControl))]
[RequireComponent(typeof(YenaUltimateControl))]
[RequireComponent(typeof(YenaOnAnimHandler))]
[RequireComponent(typeof(YenaOnDamageHandler))]

public class Yena : MySingleton<Yena>
{
    //dragin component
    [NonSerialized] public YenaAttributeControl attribute;
    [NonSerialized] public YenaDataBiding dataBiding;
    [NonSerialized] public YenaSkillManager skillManager;
    [NonSerialized] public YenaMoveController moveController;
    [NonSerialized] public CharacterController characterController;
    [NonSerialized] public YenaNormalAttackControl normalAttack;
    [NonSerialized] public YenaSpellAttackControl SpellAttack;
    [NonSerialized] public YenaDashControl Dash;
    [NonSerialized] public YenaUltimateControl ultimate;
    [NonSerialized] public YenaOnAnimHandler onAnimHandler;
    [NonSerialized] public YenaOnDamageHandler onDamageHandler;
    [NonSerialized] public Transform trans;
    public AudioSource audioSource;
    [SerializeField] public AudioClip dash_sound;
    [SerializeField] public AudioClip ultimate_sound;
    [SerializeField] public AudioClip darkrelease_sound;
    public Transform shield;
    //m_var
    private Enemy[] enemies;
    public Transform leftHand;
    public Transform leftFoot;


    private void Awake()
    {
        InitYena();
    }
    public Enemy NearestEnemy()
    {
        Dictionary<float, Enemy> dic_enemy = new Dictionary<float, Enemy>();
        float min_dis = 100000f;
        dic_enemy.Add(100000,null);
        enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if(enemy.gameObject.activeSelf)
            {
                float dis_to_player = Vector3.Distance(enemy.transform.position, this.transform.position);
                if (dic_enemy.ContainsKey(dis_to_player) == false)
                {
                    dic_enemy.Add(dis_to_player, enemy);
                    if (dis_to_player < min_dis)
                    {
                        min_dis = dis_to_player;
                    }
                }
            }
        }
        return dic_enemy[min_dis];
    }
    public void InitYena()
    {
        trans = transform;
        attribute=gameObject.GetComponent<YenaAttributeControl>();
        dataBiding=gameObject.GetComponent<YenaDataBiding>();
        skillManager = gameObject.GetComponent<YenaSkillManager>();
        moveController = gameObject.GetComponent<YenaMoveController>();
        characterController= gameObject.GetComponent<CharacterController>();
        normalAttack=gameObject.GetComponent<YenaNormalAttackControl>();
        SpellAttack=gameObject.GetComponent<YenaSpellAttackControl>();
        Dash=gameObject.GetComponent<YenaDashControl>();
        ultimate = gameObject.GetComponent<YenaUltimateControl>();
        onAnimHandler=gameObject.GetComponent<YenaOnAnimHandler>();
        onDamageHandler=gameObject.GetComponent <YenaOnDamageHandler>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
}
