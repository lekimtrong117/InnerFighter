using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class EnemySpawnInfo
{
    public int enemy_level;
    public Enemy_name enemy_name;
    public int Spawn_positon;
    public bool bounty;
}
public class EnemySpawnManager : MySingleton<EnemySpawnManager>
{
    public bool enable;
    [SerializeField] public List<EnemySpawnInfo> list_enemy_to_spawn;
    public List<SpawnRing> spawnRings;
    public int enemyRemain = 0;
    public int max_enemy_in_battleground = 5;
    public int next_enemy_index = 0;
    private void Awake()
    {
        Initt();
    }
    void Initt()
    {
        enemyRemain = 0;
        next_enemy_index = 0;
        enable = false;
    }
    private void Update()
    {
        if (enable)
        {
            if (enemyRemain < max_enemy_in_battleground)
            {

                if (next_enemy_index < list_enemy_to_spawn.Count)
                {
                    SpawnEnemy(list_enemy_to_spawn[next_enemy_index]);

                    next_enemy_index++;
                }
               
            }
        }
    }
    public void SpawnEnemy(EnemySpawnInfo spawnInfo)
    {
        enemyRemain++;
        if(spawnInfo.enemy_name==Enemy_name.FireBoss)
        {
            MusicManager.Instance.audioSource.clip = MusicManager.Instance.music3;
            MusicManager.Instance.audioSource.Play();
        }
        else if(spawnInfo.bounty==true)
        {
            MusicManager.Instance.audioSource.clip = MusicManager.Instance.music2;
            MusicManager.Instance.audioSource.Play();
        }
        spawnRings[spawnInfo.Spawn_positon].SpawnEnemy(spawnInfo.enemy_name, spawnInfo.enemy_level,spawnInfo.bounty);
    }

}
