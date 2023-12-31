using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // public GameObject enemyPrefab1;
    // public GameObject enemyPrefab2;
    // public GameObject enemyPrefab3;
    // private GameObject enemyPrefab;
    public Transform playerTransform;
    public int numberOfEnemiesToSpawn = 10;
    public float spawnRadius = 20.0f;
    public int enemies = 0;
    public int numOfSpawn = 3;
    public GameObject[] spawnPoints;
    
    // private List<GameObject> spawnPoints;


    void Start()
    {
        // spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        // spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").ToList();
        // 在游戏开始时生成怪物
        // SpawnEnemy();
        SpawnEnemyFromPoint();
    }
    
    public void SpawnEnemyFromPoint()
    {
        Debug.Log("生成怪物");
        if(numOfSpawn <= 0) return;
        numOfSpawn--;
        // foreach(var point in spawnPoints)
        // {
        //     point.gameObject.GetComponent<SpawnPoint>().Spawn();
        //     enemies++;
        // }
        for (int i = 0; i < 10; i++)
        {
            spawnPoints[i].gameObject.GetComponent<SpawnPoint>().Spawn();
            enemies++;
        }
    }

    // public void SpawnEnemy()
    // {
    //     switch(numOfSpawn)
    //     {
    //         case 5: {
    //             enemyPrefab = enemyPrefab1;
    //             break;
    //         }
    //         case 4: {
    //             enemyPrefab = enemyPrefab2;
    //             break;
    //         }
    //         case 3: {
    //             enemyPrefab = enemyPrefab1;
    //             break;
    //         }
    //         case 2: {
    //             enemyPrefab = enemyPrefab2;
    //             break;
    //         }
    //         case 1: {
    //             enemyPrefab = enemyPrefab3;
    //             break;
    //         }
    //     }
    //     for (int i = 0; i < numberOfEnemiesToSpawn; i++)
    //     {
    //         // 随机生成一个位置
    //         Vector3 randomPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
    //         randomPosition.z = 0.0f;
            
            
    //         // 检测位置是否在Plane图层上
    //         // LayerMask planeLayerMask = LayerMask.GetMask("Plane");
    //         // bool positionValid = Physics.Raycast(randomPosition + Vector3.forward * 10f, Vector3.back, Mathf.Infinity, planeLayerMask);
    //         //
    //         // if (!positionValid)
    //         // {
    //         //     // 如果位置不在Plane图层上，重新生成位置
    //         //     Debug.Log("not in plane");
    //         //     continue;
    //         // }

            
    //         // 实例化敌人Prefab
    //         GameObject enemyInstance = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    //         enemies++;

            
    //         // 获取生成的敌人的敌人控制脚本（假设脚本名为 EnemyController）
    //         EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();

    //         // if (enemyController != null)
    //         // {
    //         //     // 将玩家的Transform分配给敌人脚本
    //         //     enemyController.player = playerTransform;
    //         // }
    //     }
    //     --numOfSpawn;
    // }
}