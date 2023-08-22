using System;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textComponent; // 在 Inspector 中将 Text 组件拖拽到这里
    // private string name;
    public CardManager CardMgr;

    private void Start()
    {
        name = transform.parent.name;
        CardMgr = GameObject.Find("CardManager").GetComponent<CardManager>();
    }

    void Update()
    {
        // switch (name)
        // {
        //     case "Button1":
        //         textComponent.text = "拍马屁: " + "等级" + CardMgr.cardCounters[0];
        //         break;
        //     case "Button2":
        //         textComponent.text = "开攻: " + "等级" + CardMgr.cardCounters[1];
        //         break;
        //     case "Button3":
        //         textComponent.text = "回血: " + "等级" + CardMgr.cardCounters[2];
        //         break;
        //     case "Button4":
        //         textComponent.text = "眩晕: " + "等级" + CardMgr.cardCounters[3];
        //         break;
        // }
    }

    // 其他你需要的逻辑和方法
}