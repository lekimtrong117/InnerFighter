using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Orc : Enemy
{
    public Orc_aim_state aim_state;
    public Orc_Attack_State attack_state;
    public Orc_Die_State die_state;
    public Orc_Run_State run_state;
    public Orc_Stun_State stun_state;
    public Transform axe_hit_point;
    public LayerMask mask;
    public AudioClip runsound;
    public AudioClip aimsound;
    public override void InitEnemy()
    {
        base.InitEnemy();
        // set up fsm state
        aim_state.parent = this;
        attack_state.parent = this;
        die_state.parent = this;
        run_state.parent = this;
        stun_state.parent = this;
    }
    public override void SetUpEnemy()
    {
        base.SetUpEnemy();
        GotoState(run_state, attack_state);
    }
    public override void OnStun()
    {
        base.OnStun();
        GotoState(stun_state);
    }
    public override void OnDeath()
    {
        base.OnDeath();
        Transform blood = PoolManager.Instance.Spawn("GroundBlood");
        blood.position = blood_pos.position;
        // ajusst so that blood can be on the ground
        PoolManager.Instance.DeSpawn(this.enemyname.ToString(), this.trans);
    }
    public void OnAttackAnimHit()
    {
        Collider[] cols = Physics.OverlapSphere(axe_hit_point.position, 3, mask);//player mask player =6
        if (cols.Length > 0) 
        {
            foreach (Collider col in cols)
            {
                //damage calculation
                DamageData damage = new DamageData();
                damage.HP_Damage = 4 * attribute.current_Attack;
                damage.SP_Damage = 10;
                damage.elemental = attribute.elemental;
                //
                col.gameObject.GetComponent<YenaOnDamageHandler>().OnDamge(damage);
            }
        }
        if (CurrentState == attack_state)
        {
            GotoState(run_state, aim_state);
        }
    }
    public void OnThrowAnim()
    {
        DamageData damage = new DamageData();
        damage.HP_Damage = 4 * attribute.current_Attack;
        damage.SP_Damage = 5;
        damage.elemental = attribute.elemental;
        if (CurrentState == aim_state)
        {
            Projectile lance = PrefabManager.Instance.CreateProjectile("IceLance", trans.position + new Vector3(0, 1, 0), damage, Target_tag.Player, false,true);
            lance.FlyTo(this.trans.position+this.trans.forward*10,60,50);
            GotoState(run_state, attack_state);
        }
    }

}


