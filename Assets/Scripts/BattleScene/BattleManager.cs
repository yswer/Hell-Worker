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
        droppedItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpawnManager.numOfSpawn <=0 && enemySpawnManager.enemies == 0) battleEnd = true;
        if(battleEnd)
        {
            Debug.Log("战斗结束");
            // 显示掉落
            droppedItem.SetActive(true);
            // 门可以触发
        }
        // GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");//返回tag相同的所有物体
        // foreach(GameObject target in targets)
        // {
        //     //下面的Distance函数的距离可以根据需求设置
        //     if(Vector3.Distance(target.transform.position,gameObject.transform.position)<=1.01f)
        //     {
        //     //可以筛选出一定距离内的物体
        //     //我通常使用这个方法并结合其他方法找到我所需要的特定的游戏物体对象
        //     }
        // }
    }
}
