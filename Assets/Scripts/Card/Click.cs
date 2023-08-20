using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private CardManager CardMgr;
    public List<Sprite> imgs;
    private Image img;
    private int index = 0;
    void Start()
    {
        CardMgr = GameObject.Find("CardManager").GetComponent<CardManager>();
        switch (gameObject.name)
        {
            case "PatButton":
                index = 0;
                break;
            case "AttackButton":
                index = 1;
                break;
            case "FoodButton":
                index = 2;
                break;
            case "CakeButton":
                index = 3;
                break;
        }

        img = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        img.sprite = imgs[CardMgr.cardCounters[index]];
        if (CardMgr.cardCounters[index] == 0)
        {
            img.color = Color.gray;
        }
        else
        {
            img.color = Color.white;
        }
        
    }

    public void OnButtonClicked()
    {
        CardMgr.UseSkill(gameObject.name);
    }
}