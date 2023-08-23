using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    private void Awake()
    {
        if(GameObject.Find("CardManager"))
            DontDestroyOnLoad(this.gameObject);
    }
}