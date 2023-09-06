using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TwinDragonControl : MonoBehaviour
{
    public Transform trans;
    public float spin_speed = 2;
    public Transform white_dragon;
    public Transform black_dragon;
    public float separate_speed = 2;
    public float ultimate_cast_time = 4.33f;
    public Transform bound1;
    public Transform bound2;
    public float bound_zoom_speed;
    public Canvas kanji1;
    public Canvas kanji2;
    public Canvas kanji3;
    public Canvas kanji4;
    float timer;
    public float ultimate_damage_scale = 10;
    private void Awake()
    {
        trans = transform;
        kanji1.renderMode = RenderMode.WorldSpace;
        kanji1.worldCamera = Camera.main;
        kanji2.renderMode = RenderMode.WorldSpace;
        kanji2.worldCamera = Camera.main;
        kanji3.renderMode = RenderMode.WorldSpace;
        kanji3.worldCamera = Camera.main;
        kanji4.renderMode = RenderMode.WorldSpace;
        kanji4.worldCamera = Camera.main;
    }

    private void Start()
    {
        SetUpDragon();
    }

    private void BillBoarding()
    {
        kanji1.transform.forward = Camera.main.transform.forward;
        kanji2.transform.forward = Camera.main.transform.forward;
        kanji3.transform.forward = Camera.main.transform.forward;
        kanji4.transform.forward = Camera.main.transform.forward;
    }
    private void Update()
    {

        BillBoarding();
        trans.Rotate(0, spin_speed * Time.deltaTime, 0);
        white_dragon.localPosition = white_dragon.localPosition + new Vector3(1, 0, 0) * Time.deltaTime * separate_speed;
        black_dragon.localPosition = black_dragon.localPosition + new Vector3(-1, 0, 0) * Time.deltaTime * separate_speed;
        bound1.localScale += bound1.localScale * bound_zoom_speed * Time.deltaTime;
        bound2.localScale += bound2.localScale * bound_zoom_speed * Time.deltaTime;
        bound1.transform.localPosition = bound1.transform.localPosition + new Vector3(0, 1, 0) * Time.deltaTime * bound_zoom_speed;
        bound2.transform.localPosition = bound2.transform.localPosition + new Vector3(0, 1, 0) * Time.deltaTime * bound_zoom_speed;
        // deal damage
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            timer = 0;
            DealDamage();
            Yena.Instance.attribute.current_YingEnergy = Mathf.Lerp(Yena.Instance.attribute.current_YingEnergy, 0, Time.deltaTime*50);
                 Yena.Instance.attribute.current_YangEnergy = Mathf.Lerp(Yena.Instance.attribute.current_YangEnergy, 0, Time.deltaTime*50);
        }
    }
    public void SetUpDragon()
    {
        timer = 0;
        bound1.localScale = new Vector3(7, 7, 7);
        bound2.localScale = new Vector3(7, 7, 7);
        bound1.localPosition = new Vector3(0, 2, 0);
        bound2.localPosition = new Vector3(0, 2, 0);
        white_dragon.localPosition = new Vector3(3, 5, 0);
        black_dragon.localPosition = new Vector3(-3, 5, 0);
        StopCoroutine(DelayDissapear());
        StartCoroutine(DelayDissapear());

    }

    public void DealDamage()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            DamageData damageData = new DamageData { elemental = Elemental.Dark, HP_Damage = Yena.Instance.attribute.current_Attack * ultimate_damage_scale * (0.5f / ultimate_cast_time), SP_Damage = 1000 * (0.5f / ultimate_cast_time) };
            enemy.onDamgeHandler.OnDamge(damageData);
        }
    }
    IEnumerator DelayDissapear()
    {
        yield return new WaitForSeconds(ultimate_cast_time);
        PoolManager.Instance.DeSpawn("TwinDragon", trans);
        Yena.Instance.attribute.isUsingUltimate = false;
        Yena.Instance.attribute.current_YangEnergy = 0;
        Yena.Instance.attribute.current_YingEnergy = 0;
        Time.timeScale = 0;
        ViewManager.Instance.SwitchView(ViewIndex.SpinView);
    }

}
