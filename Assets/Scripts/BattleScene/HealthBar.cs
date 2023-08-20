using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image mask_red;
    // public Image mask_blue;
    float ori_red;
    // float ori_blue;

    // Start is called before the first frame update
    void Start()
    {
        mask_red = GameObject.Find("mask_red").GetComponent<Image>();
        // mask_blue = GameObject.Find("mask_blue").GetComponent<Image>();
        ori_red = mask_red.rectTransform.rect.width;
        // ori_blue = mask_blue.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        // 主角满血100f
        float Hp = GameObject.Find("Player").GetComponent<PlayerController>().health;
        mask_red.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ori_red * Hp/100.0f);
        // mask_blue.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ori_blue * 0.5f);
    }
}
