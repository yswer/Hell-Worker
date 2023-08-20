using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    private EnemySpawnManager enemySpawnManager;
    // public GameObject droppedItem;
    
    private bool battleEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnManager = GameObject.Find("Enemy").GetComponent<EnemySpawnManager>();
        // droppedItem = GameObject.Find("DroppedItem");
        // droppedItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpawnManager.numOfSpawn <=0 && enemySpawnManager.enemies == 0) battleEnd = true;
        if(battleEnd)
        {
            Debug.Log("战斗结束");
            // 显示掉落
            // droppedItem.SetActive(true);
            // 门可以触发
        }
        // GameObject[] targets = GameObject.FindGameObjectsWithTag("Character").OrderBy(g => g.transform.position.y()).ToArray();
        // GameObject[] targets = GameObject.FindGameObjectsWithTag("Character");
        // int i = 0;
        // foreach(GameObject target in targets)
        // {
        //     // target.GetComponent<SortingGroup>().sortingOrder = i++;
        //     // target.sortingOrder = i++;
        // }
    }
}
