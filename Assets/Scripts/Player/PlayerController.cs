using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float health = 100.0f;
    public float energy = 7.0f;
    public float damage = 10.0f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float shootInterval = 1.0f;

    private Transform closestEnemy;
    private float lastShootTime;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        // 获取玩家输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动向量
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0.0f);

        // 根据移动向量和移动速度移动玩家
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
    
    void Update()
    {
        FindClosestEnemy();
        

        // 检查是否需要发射子弹
        if (Time.time - lastShootTime >= shootInterval && closestEnemy != null)
        {
            Shoot();
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        closestEnemy = null; // 重置最近敌人

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }
    }

    void Shoot()
    {
        if (closestEnemy == null)
        {
            return;
        }

        var shootPosition = transform.position + new Vector3(-0.08000183f, 5.51f, 0f);
        // 创建子弹
        GameObject bullet = Instantiate(bulletPrefab, shootPosition, Quaternion.identity);

        // 计算子弹的移动方向
        Vector3 shootDirection = (closestEnemy.position - shootPosition).normalized;
        
        // 设置子弹的伤害
        bullet.GetComponent<Bullet>().damage = damage;

        // 给子弹添加速度
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shootDirection * bulletSpeed;

        // 更新上次发射时间
        lastShootTime = Time.time;

        Debug.Log("bullet shoot");
    }
}