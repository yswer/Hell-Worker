using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public int numberOfEnemiesToSpawn = 10;
    public float spawnRadius = 5.0f;
    public int enemies = 0;

    void Start()
    {
        // 在游戏开始时生成怪物
        SpawnEnemy();
    }
    
    
    public void SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // 随机生成一个位置
            Vector3 randomPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.z = 0.0f;

            // 实例化敌人Prefab
            GameObject enemyInstance = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemies++;

            // 获取生成的敌人的敌人控制脚本（假设脚本名为 EnemyController）
            EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                // 将玩家的Transform分配给敌人脚本
                enemyController.player = playerTransform;
            }
        }
    }
}