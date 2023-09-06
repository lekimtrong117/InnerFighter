using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataAPIController : MySingleton<DataAPIController>

{
    [NonSerialized]public bool dataInitDone = false;
    [SerializeField] public DataLocalModel dataModel;
    private void Awake()
    {
        dataInitDone = false;
        InitData(() => { dataInitDone = true;
        });
    }
    public void InitData(Action callback)
    {
        dataModel.CreateData(callback);
    }
    public int ReadLevel()
    {
        return dataModel.Read<int>(DataPath.LEVEL);
    }
    public int ReadFocus()
    {
        return dataModel.Read<int>(DataPath.FOCUS);
    }
    public int ReadCreative()
    {
        return dataModel.Read<int>(DataPath.CREATIVE);
    }
    public int ReadLucid()
    {
        return (dataModel.Read<int>(DataPath.LUCID));
    }
    public int ReadEndurance()
    {
        return dataModel.Read<int>(DataPath.ENDURANCE);
    }
    public Elemental ReadElemental()
    {
        return dataModel.Read<Elemental>(DataPath.ELEMENTAL);
    }
    public float ReadHighestScore()
    {
        return dataModel.Read<float>(DataPath.HIGHESTSCORE);
    }
    public void UpdateHighestScore(float score)
    {
        dataModel.UpdateData(DataPath.HIGHESTSCORE, score, () =>{ });
    }
    public float ReadEssence()
    {
        return dataModel.Read<float>(DataPath.ESSENCE);
    }
    public int ReadEnemyAttackPoint()
    {
        return dataModel.Read<int>(DataPath.ENEMYATTACKPOINT);
    }    
    public int ReadEnemyHealthPoint()
    {
        return dataModel.Read<int>(DataPath.ENEMYHEALTHPOINT);
    }    
    public int ReadPricePoint()
    {
        return dataModel.Read<int>(DataPath.PRICEPOINT);
    }    
    public int ReadYingLimitPoint()
    {
        return dataModel.Read<int>(DataPath.YINGLIMITPOINT);
    }    
    public bool ReadSecondChance()
    {
        return dataModel.ReadKey<bool>(DataPath.PURCHASE, "SecondChance");
    }
    public bool ReadLastChance()
    {
        return dataModel.ReadKey<bool>(DataPath.PURCHASE, "LastChance");
    }
    public bool ReadAnOptimist()
    {
        return dataModel.ReadKey<bool>(DataPath.PURCHASE, "AnOptimist");
    }
    public bool ReadBurden()
    {
        return dataModel.ReadKey<bool>(DataPath.PURCHASE, "Burden");
    }
    public bool ReadAnythingElse()
    {
        return dataModel.ReadKey<bool>(DataPath.PURCHASE, "AnythingElse");
    }
    public bool ReadInnerRunner()
    {
        bool isEnable = dataModel.ReadKey<bool>(DataPath.PURCHASE, "InnerRunner");
        return isEnable;
    }
    public bool ReadUltraUltimate()
    {
        return dataModel.ReadKey<bool>(DataPath.PURCHASE, "UltraUltimate");
    }
    

}
