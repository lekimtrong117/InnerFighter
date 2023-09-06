using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FireBoss_Ground_Shoot_State : FSM_State
{
    public FireBoss parent;
    float timer_shoot;
    float timer_state;
    public float state_dur = 7;
    public float shoot_rate = 2;
    Transform arrow;
    DamageData damage = new DamageData();
    public Vector3 arrow_scale = new Vector3(2, 1, 5);
  public float arrow_zoom_speed_z;
    public float arrow_zoom_speed_x;
    public override void OnEnter()
    {
        base.OnEnter();
        if(parent.previous_state!=parent.stun_state)
        parent.run_count++;
        if (parent.run_count > 2)
            parent.run_count = 0;
        parent.dataBiding.Shoot = true;
        parent.trans.forward = parent.dirToPlayer;
        arrow = PoolManager.Instance.Spawn("ArrowAlert");
        arrow.SetParent(parent.transform);
        arrow.localScale = arrow_scale;
        arrow.forward = parent.trans.forward;
        timer_shoot = 0;
        timer_state = 0;
        arrow.gameObject.SetActive(false);
        IEnumerator delay = DelayArrowDisAppear();
        ScenceManager.Instance.StartCoroutine(delay);
        parent.audioSource.PlayOneShot(parent.shootSound);
    }
    public override void Update()
    {
        base.Update();
        timer_shoot += Time.deltaTime;
        timer_state += Time.deltaTime;
        parent.trans.forward = parent.dirToPlayer;
        if (timer_shoot >= shoot_rate)
        {
            timer_shoot = 0;
            //damage caluculate    
            damage.HP_Damage = 4 * parent.attribute.current_Attack;
            damage.SP_Damage = 10;
            damage.elemental = Elemental.Fire;
            Projectile firedash = PrefabManager.Instance.CreateProjectile("FireDash", parent.trans.position, damage, Target_tag.Player, false, false);
            firedash.FlyTo(parent.trans.position+parent.trans.forward*10,100, 100);
            arrow.gameObject.SetActive(false);
            IEnumerator delay = DelayArrowDisAppear();
            ScenceManager.Instance.StartCoroutine(delay);
        }
        if (timer_state >= state_dur)
        {
            timer_state = 0;
            parent.GotoState(parent.run_state);
        }
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (arrow.gameObject.activeSelf == true)
            arrow.localScale = new Vector3(arrow.localScale.x + Time.deltaTime * arrow_zoom_speed_x, arrow_scale.y, arrow.localScale.z + Time.deltaTime * arrow_zoom_speed_z);
    }
    IEnumerator DelayArrowDisAppear()
    {
        yield return new WaitForSeconds(3);
        if(arrow!=null)
        {
            if (parent.CurrentState == parent.ground_shoot_state)
            {
                parent.audioSource.PlayOneShot(parent.shootSound);
                arrow.gameObject.SetActive(true);
                arrow.localScale = arrow_scale;
                arrow.forward = parent.trans.forward;
            }
           
        }
    }
    public override void Exit()
    {
        base.Exit();
        if (arrow != null)
        {
            arrow.localScale = Vector3.one;
            PoolManager.Instance.DeSpawn("ArrowAlert", arrow);
        }
    }
}
