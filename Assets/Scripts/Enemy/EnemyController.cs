using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public float health = 10.0f;
    public int damagePerAttack = 10;
    public float attackInterval = 1.0f; // 攻击间隔
    
    private EnemySpawnManager spawnManager;
    private bool canAttack = true;

    // private void Start()
    // {
    //     spawnManager = GameObject.Find("Enemy").GetComponent<EnemySpawnManager>();
    // }

    void Start()
    {        
        spawnManager = GameObject.Find("Enemy").GetComponent<EnemySpawnManager>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            spawnManager.enemies--;
            if (spawnManager.enemies <= 0)
            {
                // if(spawnManager.numOfSpawn > 0) spawnManager.SpawnEnemy();
                if(spawnManager.numOfSpawn > 0) spawnManager.SpawnEnemyFromPoint();
            }
        }
        player = GameObject.Find("Player").GetComponent<Transform>();
        // 计算朝向玩家的方向
        Vector3 moveDirection = (player.position - transform.position).normalized;
        // Debug.Log("移动" + moveDirection * moveSpeed * Time.deltaTime);
        // 移动敌人朝向玩家
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 如果可以攻击且与玩家重合，就开始攻击协程
        if (canAttack && IsCollidingWithPlayer())
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    // 检查是否与玩家重合............................可能需要重写，cllider太小
    bool IsCollidingWithPlayer()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            return col.bounds.Intersects(player.GetComponent<Collider2D>().bounds);
        }
        return false;
    }

    // 攻击协程
    IEnumerator AttackCoroutine()
    {
        canAttack = false;

        // 对玩家造成伤害的逻辑
        // 例如：调用玩家脚本的伤害函数
        // player.GetComponent<PlayerHealth>().TakeDamage(damagePerAttack);
        Debug.Log("Enemy Hit");
        player.gameObject.GetComponent<PlayerController>().health -= damagePerAttack;
        yield return new WaitForSeconds(attackInterval);

        canAttack = true;
    }
    
}