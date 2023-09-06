using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRing : MonoBehaviour
{
    public Transform SpawnEffect;
    public Transform trans;
    public float effect_duration = 3;
    public float delay_time_before_enemy_appear = 2;
    IEnumerator delaySpawn;
    IEnumerator delayEffect;
    private void Update()
    {

    }
    private void Awake()
    {
        InitRing();
    }
    public void InitRing()
    {
        trans = transform;
        SpawnEffect = gameObject.GetComponentInChildren<ParticleSystem>().transform;
        SpawnEffect.gameObject.SetActive(false);
    }
    public void SpawnEnemy(Enemy_name enemy_name, int enemy_level,bool bounty)
    {//
        // ring appear first
        
        SpawnEffect.gameObject.SetActive(true);
        if(delayEffect!=null)
        {
            StopCoroutine(delayEffect);
        }
        delayEffect = SpawnEffectDisappear();
        StartCoroutine(delayEffect);
        delaySpawn = EnemyDelayAppear(enemy_name, enemy_level,bounty);
        StartCoroutine(delaySpawn);
    }
    IEnumerator SpawnEffectDisappear()
    {
        yield return new WaitForSeconds(effect_duration);
        SpawnEffect.gameObject.SetActive(false);
    }
    IEnumerator EnemyDelayAppear(Enemy_name name, int enemy_level,bool bounty)
    {
        yield return new WaitForSeconds(delay_time_before_enemy_appear);
        Enemy enemy = PoolManager.Instance.Spawn(name.ToString()).gameObject.GetComponent<Enemy>();
        enemy.characterController.enabled = false;
        enemy.trans.position = trans.position;
        enemy.characterController.enabled = true;
        enemy.attribute.level = enemy_level;
        enemy.attribute.SetUpAttribute();
        enemy.SetUpEnemy();
        if (bounty == true)
            enemy.attribute.bounty = true;
        else enemy.attribute.bounty = false;
 
    }

}

