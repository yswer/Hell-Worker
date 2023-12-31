using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class BattleManager : MonoBehaviour
{
    private EnemySpawnManager enemySpawnManager;
    public GameObject dialogBox;
    // public GameObject droppedItem;
    
    private bool battleEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnManager = GameObject.Find("Enemy").GetComponent<EnemySpawnManager>();
        // droppedItem = GameObject.Find("DroppedItem");
        // droppedItem.SetActive(false);
        dialogBox = GameObject.Find("DialogBox");
        dialogBox.SetActive(false);
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
            dialogBox.SetActive(true);
            // 门可以触发
        }


        // GameObject[] targets = GameObject.FindGameObjectsWithTag("Character").OrderBy(g => g.transform.position.y()).ToArray();

        // List<GameObject> targets = GameObject.FindGameObjectsWithTag("Character").ToList();
        // targets.Sort((ob1, ob2) => (int)((ob1.transform.position.y - ob2.transform.position.y) * 1000));
        // int i = 0;
        // foreach(var target in targets)
        // {
        //     target.GetComponent<SortingGroup>().sortingOrder = i++;
        //     Debug.Log("排序");
        // }
    }

    public bool BattleEnd()
    {
        return battleEnd;
    }
}
