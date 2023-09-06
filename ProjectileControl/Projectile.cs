using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{     // drag in component
    [NonSerialized] public Collider _collider;
    [NonSerialized] public Rigidbody rigidbody_;
    [NonSerialized] public Transform trans;
    //m_var
    public string projectile_name;
    [NonSerialized] public Target_tag target_tag;
    [NonSerialized] public bool canbe_deflected = true;
    [NonSerialized] public bool can_deflect = true;
    [NonSerialized] public DamageData damageData = new DamageData();
    public AudioSource audioSource;
    public static float deflected_fly_speed = 30;
    public bool can_deal_stay_damage;
    IEnumerator delay_stay;
    public DamageData damagedata_per_fixupdate;
    IEnumerator delay_damge;
    public static float stay_damgae_rate=0.3f;
    public virtual void Awake()
    {
        InitProjectile();
    }
    void InitProjectile()
    {
        audioSource = GetComponent<AudioSource>();
        trans = transform;
        _collider = GetComponent<Collider>();
        rigidbody_ = GetComponent<Rigidbody>();
        _collider.isTrigger = true;
        rigidbody_.isKinematic = true;
        DeclareProjectileNameAndTag();
    }
    public virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == this.target_tag.ToString())
        {
            collider.gameObject.GetComponent<CharacterOnDamageHandler>().OnDamge(this.damageData);
        }
        // khi 2 projectile collide
        if (collider.gameObject.tag == "Projectile")
        {
            Projectile colliProjectile = collider.gameObject.GetComponent<Projectile>();
            //yena projectile will deflect enemy projectile
            if (this.target_tag == Target_tag.Enemy && colliProjectile.target_tag == Target_tag.Player)
                // only if project can be deflect
                if (colliProjectile.canbe_deflected && this.can_deflect)
                {
                
                    PopUpDeflect(colliProjectile.trans.position);
                    colliProjectile.SetUp(colliProjectile.trans.position, colliProjectile.damageData, Target_tag.Enemy, false, false);
                    // deflected project will reverse direction and fly with delfected_fly_speed , not before speed
                    colliProjectile.FlyTo(colliProjectile.trans.position - colliProjectile.trans.forward * 30, deflected_fly_speed, 30);
                }
        }
    }
    public void PopUpDeflect(Vector3 deflect_place)
    {
        PopUpTextControl pop_Up = PoolManager.Instance.Spawn("PopUpText").gameObject.GetComponent<PopUpTextControl>();
        pop_Up.SetUp(deflect_place, "DEFLECT", 15, Color.green);
    }
    public virtual void SetUp(Vector3 start_point, DamageData damageData, Target_tag target_Tag, bool can_deflect, bool canbe_delfected)
    {
        trans.DOKill();
        trans.position = start_point;
        this.damageData = damageData;
        this.target_tag = target_Tag;
        this.can_deflect = can_deflect;
        this.canbe_deflected = canbe_delfected;
        this.can_deal_stay_damage = false;
        audioSource.PlayOneShot(audioSource.clip) ;
        stay_damgae_rate = 0.3f;
    }
    public virtual void FlyTo(Vector3 targetPoint, float fly_speed, float max_fly_distance)
    {
        trans.forward = targetPoint - trans.position;
        trans.forward = new Vector3(trans.forward.x, 0, trans.forward.z);
        Vector3 dir_to_target = (targetPoint - trans.position).normalized;
        dir_to_target.y = 0;
        Vector3 point_to_Flyto = trans.position + max_fly_distance * dir_to_target;
        trans.DOMove(point_to_Flyto, max_fly_distance / fly_speed).SetEase(Ease.Linear).OnComplete(() =>
        {
            PoolManager.Instance.DeSpawn(projectile_name, trans);
        });
    }
    public virtual void FlyToAnDealStayDamge(Vector3 targetPoint, float fly_speed, float max_fly_distance)
    {
        can_deal_stay_damage = true;
        trans.forward = targetPoint - trans.position;
        trans.forward = new Vector3(trans.forward.x, 0, trans.forward.z);
        Vector3 dir_to_target = (targetPoint - trans.position).normalized;
        dir_to_target.y = 0;
        Vector3 point_to_Flyto = trans.position + max_fly_distance * dir_to_target;
        trans.DOMove(point_to_Flyto, max_fly_distance / fly_speed).SetEase(Ease.Linear).OnComplete(() =>
        {
            PoolManager.Instance.DeSpawn(projectile_name, trans);
        });
    }
    public virtual void StayAT_INandDealStayDamage(Vector3 stay_at, float in_duration)
    {
        can_deal_stay_damage = true;
        trans.position = stay_at;
        if (delay_stay != null)
        {
            StopCoroutine(delay_stay);
        }
        delay_stay = DelayStay(in_duration);
        StartCoroutine(delay_stay);

    }
    public virtual void StayAT_IN(Vector3 stay_at, float in_duration)
    {

        trans.position = stay_at;
        if (delay_stay != null)
        {
            StopCoroutine(delay_stay);
        }
        delay_stay = DelayStay(in_duration);
        StartCoroutine(delay_stay);
    }
    IEnumerator DelayStay(float duration)
    {
        yield return new WaitForSeconds(duration);
        PoolManager.Instance.DeSpawn(projectile_name, this.trans);
    }
    public virtual void StayAT_IN_AND_SCALE(Vector3 stay_at, float in_duration,float scale)
    {
        trans.position = stay_at;
        Vector3 old_scale = trans.localScale;
        trans.localScale = trans.localScale * scale;
        if (delay_stay != null)
        {
            StopCoroutine(delay_stay);
        }
        delay_stay = DelayStay_AndScaleBack(in_duration,old_scale);
        StartCoroutine(delay_stay);
    }
    IEnumerator DelayStay_AndScaleBack(float duration, Vector3 old_scale)
    {
        yield return new WaitForSeconds(duration);
        trans.localScale = old_scale;
        PoolManager.Instance.DeSpawn(projectile_name, this.trans);
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == this.target_tag.ToString() && this.can_deal_stay_damage)
        {
            collider.gameObject.GetComponent<CharacterOnDamageHandler>().OnDamge(damageData);
            this.can_deal_stay_damage = false;
            if (delay_damge != null)
                StopCoroutine(delay_damge);
            delay_damge = DelayDamage();
            StartCoroutine(DelayDamage());
        }
    }
    
   public IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds(stay_damgae_rate);
        this.can_deal_stay_damage = true;      
    }

    public virtual void DropAt(Vector3 drop_Point, float dropSpeed)
    {
        float dis = Vector3.Distance(drop_Point, trans.position);
        trans.DOMove(drop_Point, dis / dropSpeed).OnComplete(() =>
        {
            PoolManager.Instance.DeSpawn(projectile_name, trans);
        });
    }
    public abstract void DeclareProjectileNameAndTag();
}

