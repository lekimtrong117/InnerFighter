using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataSchema
{

}
[Serializable]
public class UseData
{
    [SerializeField] public float highestscore;
    [SerializeField] public PlayerStat playerstat;
    [SerializeField] public DifficultModidier difficultmodifier;
    [SerializeField] public float essence;
    [SerializeField] public Dictionary<string, bool> dicpurchase;

}
[Serializable]
public class PlayerStat
{
    [SerializeField] public int level;
    [SerializeField] public int focus;
    [SerializeField] public int creative;
    [SerializeField] public int lucid;
    [SerializeField] public int endurance;
    [SerializeField] public Elemental elemental;
}
[Serializable]
public class DifficultModidier
{
    [SerializeField] public int enemyattackpoint;
    [SerializeField] public int enemyhealthpoint;
    [SerializeField] public int pricepoint;
    [SerializeField] public int yinglimitpoint;
}
