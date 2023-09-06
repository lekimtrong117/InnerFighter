using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class YangEssen : Projectile
{
    [NonSerialized] public bool isConsumed;
    float dis_to_player;
    public float speed_when_near_player = 1;
    public float near_distance = 10;
    float timer;
    float delay_fly = 3;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= delay_fly)
        {
            if (isConsumed == false)
                dis_to_player = Vector3.Distance(this.trans.position, Yena.Instance.trans.position);
            if (dis_to_player <= near_distance)
            {
                Vector3 dir_to_player = new Vector3();
                dir_to_player = Yena.Instance.trans.position - this.trans.position;
                dir_to_player.Normalize();
                dir_to_player.y = 0;
                trans.position = trans.position + dir_to_player * speed_when_near_player * Time.fixedDeltaTime;
            }
        }
    }

    public override void DeclareProjectileNameAndTag()
    {
        this.projectile_name = "YangEssen";
        this.gameObject.tag = "Projectile";
    }
    public override void SetUp(Vector3 start_point, DamageData damageData, Target_tag target_Tag, bool can_deflect, bool canbe_delfected)
    {
        base.SetUp(start_point, damageData, target_Tag, can_deflect, canbe_delfected);
        isConsumed = false;
        timer = 0;

    }
    public override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == this.target_tag.ToString() && isConsumed == false)
        {
            MusicManager.Instance.PlayPickUpSound();
            Yena.Instance.attribute.current_YangEnergy += this.damageData.HP_Damage;
            PrefabManager.Instance.CreatePopUpText(this.trans.position, "+" + this.damageData.HP_Damage.ToString(),20, Color.white);
            PoolManager.Instance.DeSpawn("YangEssen", this.trans);
        }
    }
    public override void FlyTo(Vector3 targetPoint, float fly_speed, float max_fly_distance)
    {
        isConsumed = true;
        trans.forward = targetPoint - trans.position;
        trans.forward = new Vector3(trans.forward.x, 0, trans.forward.z);
        trans.DOMove(targetPoint,0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            PoolManager.Instance.DeSpawn(projectile_name, trans);
        });
    }
}
