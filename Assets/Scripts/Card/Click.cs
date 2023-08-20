using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public CardManager CardMgr;
    void Start()
    {
        CardMgr = GameObject.Find("CardManager").GetComponent<CardManager>();
    }
    public void OnButtonClicked()
    {
        CardMgr.UseSkill(gameObject.name);
    }
}