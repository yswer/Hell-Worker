using System;
using UnityEngine;

public class CardPickUp : MonoBehaviour
{
    private CardManager CardMgr;

    private void Start()
    {
        CardMgr = GameObject.Find("CardManager").GetComponent<CardManager>();
    }

    public void PickUpCard()
    {
        if (CompareTag("Card1"))
        {
            CardMgr.cardCounters[0]++;
        }
        else if (CompareTag("Card2"))
        {
            CardMgr.cardCounters[1]++;
        }
        else if (CompareTag("Card3"))
        {
            CardMgr.cardCounters[2]++;
        }
        else if (CompareTag("Card4"))
        {
            CardMgr.cardCounters[3]++;
        }

        Destroy(gameObject);
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked Up");
            PickUpCard();
        }
    }
}