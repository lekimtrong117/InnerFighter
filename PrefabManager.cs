using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrefabManager : MySingleton<PrefabManager>
{
    private void Awake()
    {
        CreateScencePrefab();
    }
    public Transform CreateStunEffect(Transform parent, float parent_head_height, float duration)
    {
        Transform stuneffect = PoolManager.Instance.Spawn("StunEffect");
        stuneffect.SetParent(parent);
        stuneffect.localPosition = new Vector3(0, parent_head_height, 0);
        IEnumerator delay = DelayChamThan(stuneffect, duration);
        StartCoroutine(delay);
        return stuneffect;
    }
    IEnumerator DelayStunEffect(Transform chamthan, float duration)
    {
        yield return new WaitForSeconds(duration);
        PoolManager.Instance.DeSpawn("StunEffect", chamthan);
    }
    public Projectile CreateProjectile(string proj_name, Vector3 pos, DamageData damageData, Target_tag target_Tag, bool can_Deflect, bool canbe_Deflected)
    {
        Projectile projectile = PoolManager.Instance.Spawn(proj_name).gameObject.GetComponent<Projectile>();
        projectile.SetUp(pos, damageData, target_Tag, can_Deflect, canbe_Deflected);
        return projectile;
    }
    public void CreateChamThan(Transform parent, float parent_head_height, float duration)
    {
        Transform chamthan = PoolManager.Instance.Spawn("ChamThan");
        chamthan.SetParent(parent);
        chamthan.localPosition = new Vector3(0, parent_head_height, 0);
        IEnumerator delay = DelayChamThan(chamthan, duration);
        StartCoroutine(delay);
    }
    IEnumerator DelayChamThan(Transform chamthan, float duration)
    {
        yield return new WaitForSeconds(duration);
        PoolManager.Instance.DeSpawn("ChamThan", chamthan);
    }
    public void CreateRoundAlertThenCallBack(Vector3 pos, float duration, float scale, Action callback)
    {
        Transform round = PoolManager.Instance.Spawn("RoundAlert");
        round.position = pos;
        round.localScale = scale * Vector3.one;
        IEnumerator delay = DelayRoundAlert(duration, callback, round);
        StartCoroutine(delay);
    }
    IEnumerator DelayRoundAlert(float duration, Action callback, Transform round)
    {
        yield return new WaitForSeconds(duration);
        PoolManager.Instance.DeSpawn("RoundAlert", round);
        callback.Invoke();
    }
    public void CreateArrowAlertThenCallBack(Vector3 pos, float duration, float scale, Action callback)
    {
        Transform arrow = PoolManager.Instance.Spawn("ArrowAlert");
        arrow.position = pos;
        arrow.localScale = scale * Vector3.one;
        IEnumerator delay = DelayArrowAlert(duration, callback, arrow);
        StartCoroutine(delay);
    }
    IEnumerator DelayArrowAlert(float duration, Action callback, Transform round)
    {
        yield return new WaitForSeconds(duration);
        PoolManager.Instance.DeSpawn("ArrowAlert", round);
        callback.Invoke();
    }

    public void CreatePopUpText(Vector3 at_pos, string text, float font_size, Color color)
    {
        PopUpTextControl pop_up = PoolManager.Instance.Spawn("PopUpText").gameObject.GetComponent<PopUpTextControl>();
        pop_up.SetUp(at_pos, text, font_size, color);
    }
    public Transform CreateNPCDialog(Transform parent, Vector3 local_pos, string text, float fontsize, Color color, float dur)
    {
        NPCDialog dialog = PoolManager.Instance.Spawn("NPCDialog").gameObject.GetComponent<NPCDialog>();
        dialog.SetUp(parent, local_pos, text, fontsize, color, dur);
        return dialog.transform;
    }
    public void CreatePreFabPool(string prefabname, string prefabpath, int total)
    {
        GameObject prefab = (GameObject)Resources.Load(prefabpath, typeof(GameObject));
        Transform prefabTransform = prefab.transform;
        TrongPool newPool = new TrongPool { namePool = prefabname, prefab_ = prefabTransform, total = total };
        PoolManager.Instance.AddNewPool(newPool);

    }
    public void CreateScencePrefab()
    {
        ////
        //////
        //////
        ///--------------------------EFFECT-------------------
        //
      
            PrefabManager.Instance.CreatePreFabPool("PopUpText", "PopUpText", 20);
        PrefabManager.Instance.CreatePreFabPool("NPCDialog", "NPCDialog",2);


        //
        if (PoolManager.Instance.dicPool_.ContainsKey("GroundBlood") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("GroundBlood", "Effect/GroundBlood", 5);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("ChamThan") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("ChamThan", "ChamThan", 10);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("RoundAlert") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("RoundAlert", "Effect/RoundAlert", 40);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("ArrowAlert") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("ArrowAlert", "Effect/ArrowAlert", 20);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("StunEffect") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("StunEffect", "StunEffect", 10);
        }
        ///
        ///
        ///---------------------------------------ENEMY---------------
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.RedNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.RedNinja.ToString(), "Enemy/" + Enemy_name.RedNinja.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.BlueNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.BlueNinja.ToString(), "Enemy/" + Enemy_name.BlueNinja.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.GreenNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.GreenNinja.ToString(), "Enemy/" + Enemy_name.GreenNinja.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.PurpleNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.PurpleNinja.ToString(), "Enemy/" + Enemy_name.PurpleNinja.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.WhiteNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.WhiteNinja.ToString(), "Enemy/" + Enemy_name.WhiteNinja.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.RedFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.RedFatDragon.ToString(), "Enemy/" + Enemy_name.RedFatDragon.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.BlueFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.BlueFatDragon.ToString(), "Enemy/" + Enemy_name.BlueFatDragon.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.GreenFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.GreenFatDragon.ToString(), "Enemy/" + Enemy_name.GreenFatDragon.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.PurpleFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.PurpleFatDragon.ToString(), "Enemy/" + Enemy_name.PurpleFatDragon.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.WhiteFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.WhiteFatDragon.ToString(), "Enemy/" + Enemy_name.WhiteFatDragon.ToString(), 3);
        }

        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.BigBlueNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.BigBlueNinja.ToString(), "Enemy/" + Enemy_name.BigBlueNinja.ToString(), 3);

        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.BigWhiteNinja.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.BigWhiteNinja.ToString(), "Enemy/" + Enemy_name.BigWhiteNinja.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.BigGreenFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.BigGreenFatDragon.ToString(), "Enemy/" + Enemy_name.BigGreenFatDragon.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.BigRedFatDragon.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.BigRedFatDragon.ToString(), "Enemy/" + Enemy_name.BigRedFatDragon.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.Orc.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.Orc.ToString(), "Enemy/" + Enemy_name.Orc.ToString(), 3);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey(Enemy_name.FireBoss.ToString()) == false)
        {
            PrefabManager.Instance.CreatePreFabPool(Enemy_name.FireBoss.ToString(), "Enemy/" + Enemy_name.FireBoss.ToString(), 1);
        }
        /////////////////////////////////////////////PROJECTILE//////////////////////////////////////////////
        if (PoolManager.Instance.dicPool_.ContainsKey("TwinDragon") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("TwinDragon", "Effect/TwinDragon", 2);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("GiantFireRing") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("GiantFireRing", "Projectile/GiantFireRing", 2);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("WaterSplash") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("WaterSplash", "Projectile/WaterSplash", 10);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("SmallWaterSplash") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("SmallWaterSplash", "Projectile/SmallWaterSplash", 20);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("FireBall") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("FireBall", "Projectile/FireBall", 30);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("FireRing") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("FireRing", "Projectile/FireRing", 15);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("FireDash") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("FireDash", "Projectile/FireDash", 20);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("WaterBall") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("WaterBall", "Projectile/WaterBall", 20);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("RockSpike") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("RockSpike", "Projectile/RockSpike", 15);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("LeafStorm") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("LeafStorm", "Projectile/LeafStorm", 15);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("ElectricBall") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("ElectricBall", "Projectile/ElectricBall", 15);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("Thunder") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("Thunder", "Projectile/Thunder", 10);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("IceHammer") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("IceHammer", "Projectile/IceHammer", 10);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("IceLance") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("IceLance", "Projectile/IceLance", 10);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("IceSword") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("IceSword", "Projectile/IceSword", 10);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("YangEssen") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("YangEssen", "Projectile/YangEssen", 10);
        }
        PrefabManager.Instance.CreatePreFabPool("DarkRelease", "Projectile/DarkRelease", 5);
        PrefabManager.Instance.CreatePreFabPool("Chest", "Projectile/Chest", 10);

    }
}
