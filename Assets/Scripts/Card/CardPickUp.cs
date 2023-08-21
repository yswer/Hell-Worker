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
            
            if(CardMgr.cardCounters[0]<5) CardMgr.cardCounters[0]++;
        }
        else if (CompareTag("Card2"))
        {
            if(CardMgr.cardCounters[1]<5) CardMgr.cardCounters[1]++;
        }
        else if (CompareTag("Card3"))
        {
            if(CardMgr.cardCounters[2]<5) CardMgr.cardCounters[2]++;
        }
        else if (CompareTag("Card4"))
        {
            if(CardMgr.cardCounters[3]<5) CardMgr.cardCounters[3]++;
        }

        Destroy(gameObject);
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Picked Up");
            PickUpCard();
        }
    }
}