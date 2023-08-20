using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private EnemySpawnManager enemySpawnManager;
    public GameObject droppedItem;
    
    private bool battleEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnManager = GameObject.Find("Enemy").GetComponent<EnemySpawnManager>();
        enemySpawnManager.SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
