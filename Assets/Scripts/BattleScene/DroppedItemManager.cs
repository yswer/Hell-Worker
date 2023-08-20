using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedItemManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerIn2D;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerIn2D)
        {
            Debug.Log("显示掉落物品详情");
            dialogBox.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        // if(other.gameObject.CompareTag("Player")
        //     && other.GetType().ToString() == "Unity.Engine.CapsuleCollider2D")
        // {
            Debug.Log("碰到掉落物品");
            isPlayerIn2D = true;
        // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("离开掉落物品范围");
        isPlayerIn2D = false;
        dialogBox.SetActive(false);
    }
}
