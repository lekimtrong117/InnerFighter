using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyElementalIndicator : MonoBehaviour
{
    public Canvas canvas;
    [NonSerialized] Enemy enemy;
    Image image;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        enemy = canvas.gameObject.GetComponentInParent<Enemy>();
        image = gameObject.GetComponent<Image>();
    }
    public void Start()
    {
        if (enemy.enemyname==Enemy_name.FireBoss)
        {
            SetUpElemenIndicator();
        }
    }
    public void SetUpElemenIndicator()
    {
        switch (enemy.attribute.elemental)
        {
            case Elemental.Fire:
                {
                    image.sprite = Resources.Load<Sprite>("UI/Element/Fire");
                    break;
                }
            case Elemental.Water:
                {
                    image.sprite = Resources.Load<Sprite>("UI/Element/Water");
                    break;
                }
            case Elemental.Electric:
                {
                    image.sprite = Resources.Load<Sprite>("UI/Element/Electric");
                    break;
                }
            case Elemental.Grass:
                {
                    image.sprite = Resources.Load<Sprite>("UI/Element/Grass");
                    break;

                }
            case Elemental.Ice:
                {
                    image.sprite = Resources.Load<Sprite>("UI/Element/Ice");
                    break;
                }
            case Elemental.Dark:
                {
                    image.sprite = Resources.Load<Sprite>("UI/Element/Dark");
                    break;
                }
        }

    }
}
