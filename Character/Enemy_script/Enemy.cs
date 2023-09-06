using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyAttributeControl))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(EnemyDataBinding))]
[RequireComponent(typeof(EnemyOnDamgeHandler))]
public class Enemy : FSM_System
{

    public Enemy_name enemyname;
    //dragin component
    public Transform blood_pos;
    [NonSerialized] public GameObject player;
    [NonSerialized] public GameObject chamThan;
    [NonSerialized] public Transform StunEffect;
    [NonSerialized] public Animator animator;
    [NonSerialized] public Transform trans;
    [NonSerialized] public CharacterController characterController;
    [NonSerialized] public EnemyAttributeControl attribute;
    [NonSerialized] public EnemyOnDamgeHandler onDamgeHandler;
    [NonSerialized]public AudioSource audioSource;
    //gravity
 public float gravity = -9.8f;
    [NonSerialized] public float groundedGravity = -0.5f;
    //m_var
    [NonSerialized] public float distance_to_player;
    [NonSerialized] public Vector3 dirToPlayer;
    [NonSerialized] public Vector3 moveVector3D;
    [NonSerialized] public EnemyDataBinding dataBiding;
    IEnumerator pushback_delay;
    public LayerMask playermask;
    //enemy param    
    public override void Awake()
    {
        base.Awake();
        InitEnemy();
    }
    public override void Start()
    {
        base.Start();
        SetUpEnemy();
    }
    public override void Update()
    {
        // handle gravity
        moveVector3D.x = 0;
        moveVector3D.z = 0;
        HandleGravity();
        characterController.Move(moveVector3D);
        //dir to player
        dirToPlayer = player.transform.position - trans.position;
        dirToPlayer.y = 0;
        dirToPlayer.Normalize();
        // update distance to player
        distance_to_player = Vector3.Distance(player.transform.position, trans.position);
        // state update is at the end, not at begin
        //
        //
        //
        base.Update();
    }
    public virtual void InitEnemy()
    {
        this.gameObject.tag = "Enemy";
        trans = transform;
        animator = gameObject.GetComponent<Animator>();
        characterController = gameObject.GetComponent<CharacterController>();
        attribute = gameObject.GetComponent<EnemyAttributeControl>();
        onDamgeHandler = gameObject.GetComponent<EnemyOnDamgeHandler>();
        dataBiding = gameObject.GetComponent<EnemyDataBinding>();
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void SetUpEnemy()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //dir to player
        dirToPlayer = player.transform.position - trans.position;
        dirToPlayer.y = 0;
        dirToPlayer.Normalize();

    }
    public void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            moveVector3D.y = groundedGravity;
        }
        else
        {
            moveVector3D.y += Time.deltaTime * gravity;
        }
    }
    public virtual void OnDeath()
    {
        if(attribute.bounty==true)
        {
            var chest = PrefabManager.Instance.CreateProjectile("Chest", this.trans.position, new DamageData(), Target_tag.Player, false, false);

        }    
        //callculate essen point
        DamageData essenvalue = new DamageData();
        essenvalue.HP_Damage = this.attribute.Upgraded_Essen;
        //
        YangEssen yangEssen =PoolManager.Instance.Spawn("YangEssen").gameObject.GetComponent<YangEssen>();
        yangEssen.SetUp(this.trans.position, essenvalue, Target_tag.Player, false, false);
        attribute.isAlive = false;
        if (EnemySpawnManager.Instance.enable == true) 
        EnemySpawnManager.Instance.enemyRemain--;
        //then go to die state in child class;
    }
    public virtual void OnStun()
    {
        attribute.isStunning = true;
        // then go to stun state in child class;
    }
    public virtual void OnBeingPushBack()
    {
        attribute.canbePush = false;
        if (pushback_delay != null)
        {
            StopCoroutine(pushback_delay);
        }
        pushback_delay = DelayPushBack();
        StartCoroutine(pushback_delay);
    }
    IEnumerator DelayPushBack()
    {
        yield return new WaitForSeconds(1f);
        attribute.canbePush = true;
    }
    public virtual void OnDieAnimEnd()
    {
        Transform blood = PoolManager.Instance.Spawn("GroundBlood");
        blood.position = blood_pos.position;
        // ajusst so that blood can be on the ground
        PoolManager.Instance.DeSpawn(this.enemyname.ToString(), this.trans);
    }

}
public enum Enemy_name
{
    RedNinja=0,
    BlueNinja=1,
    GreenNinja=2,
    PurpleNinja=3,
    WhiteNinja=4,
    RedFatDragon=5,
    BlueFatDragon=6,
    GreenFatDragon=7,
    PurpleFatDragon=8,
    WhiteFatDragon=9,
    BigWhiteNinja=10,
    BigBlueNinja=11,
    BigGreenFatDragon=12,
    BigRedFatDragon=13,
    Orc=14,
    FireBoss=15,
}