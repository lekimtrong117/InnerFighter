using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnDamgeHandler : CharacterOnDamageHandler
{
    public Enemy enemy;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        duration = 0.2f;
    }
    public override void OnDamge(DamageData damageData)
    {
        if (enemy.attribute.isAlive == true)
        {
            base.OnDamge(damageData);
            effectiveness_ratio = ElementalManager.ElementalEffectiveRatio(enemy.attribute.elemental, damageData.elemental);
            if (enemy.attribute.isBlocking == true)
            {
                PrefabManager.Instance.CreatePopUpText(enemy.trans.position, "BLOCKED", 20, Color.blue);
            }
            else
            {
                MusicManager.Instance.PlayHitEffect();
                enemy.attribute.currentHP -= damageData.HP_Damage * effectiveness_ratio;
                Yena.Instance.attribute.score += damageData.HP_Damage * effectiveness_ratio;
                HPdamgage = damageData.HP_Damage * effectiveness_ratio;
                PopUpDamage();
            }
            if (enemy.attribute.currentHP <= 0 && enemy.attribute.isAlive == true)
            {
                enemy.OnDeath();
            }
            //if enemy is stunning , they will not take more stun damgge
            if (enemy.attribute.isStunning == false && enemy.attribute.isAlive == true)
            {
                if (enemy.attribute.isResistStun)
                {
                    damageData.SP_Damage = damageData.SP_Damage * 0.05f;
                }
                enemy.attribute.currentSP += damageData.SP_Damage;
                if (enemy.attribute.currentSP >= enemy.attribute.upgraded_max_SP)
                {
                    enemy.OnStun();
                }
            }
            
            }
        }
    }

