using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Chest : Projectile
{
    bool isCollected;
    public override void DeclareProjectileNameAndTag()
    {
        this.gameObject.tag = "Projectile";
        this.projectile_name = "Chest";
    }
    public override void SetUp(Vector3 start_point, DamageData damageData, Target_tag target_Tag, bool can_deflect, bool canbe_delfected)
    {
        base.SetUp(start_point, damageData, target_Tag, can_deflect, canbe_delfected);
        this.isCollected = false;
    }
    public override void OnTriggerEnter(Collider collider)
    {

        if (this.target_tag.ToString() == collider.gameObject.tag && isCollected == false)
        {
            isCollected = true;
            this.StayAT_IN(this.trans.position,1);
            MusicManager.Instance.PlayGoldSound();
            float r = UnityEngine.Random.Range(100, 1000);
            float essen_number = (r / 100);
            int count = Mathf.RoundToInt(essen_number);
            for (int i = 0; i < count; i++)
            {
                Quaternion q = Quaternion.Euler(0, i * 36, 0);
                Vector3 spaw_pos = trans.position + q * trans.forward * 7;
                damageData = new DamageData();
                damageData.HP_Damage = 100;
                var yang = PrefabManager.Instance.CreateProjectile("YangEssen", spaw_pos, damageData, Target_tag.Player, false, false);
            }
        }
    }
}
