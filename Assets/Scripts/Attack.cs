using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float shootInterval = 1.0f;

    private Transform closestEnemy;
    private float lastShootTime;

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

        // 创建子弹
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 计算子弹的移动方向
        Vector3 shootDirection = (closestEnemy.position - transform.position).normalized;

        // 给子弹添加速度
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shootDirection * bulletSpeed;

        // 更新上次发射时间
        lastShootTime = Time.time;
    }
}