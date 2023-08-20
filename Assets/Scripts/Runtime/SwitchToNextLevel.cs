using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToNextLevel : MonoBehaviour
{
    private BattleManager battleManager;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.Find("Battle").GetComponent<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // buildIndex ——build settings中的idx
        if(battleManager.BattleEnd())
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
