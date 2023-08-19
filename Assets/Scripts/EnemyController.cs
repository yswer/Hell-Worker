using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public int damagePerAttack = 10;
    public float attackInterval = 1.0f; // 攻击间隔

    private bool canAttack = true;

    void Update()
    {
        // 计算朝向玩家的方向
        Vector3 moveDirection = (player.position - transform.position).normalized;

        // 移动敌人朝向玩家
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 如果可以攻击且与玩家重合，就开始攻击协程
        if (canAttack && IsCollidingWithPlayer())
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    // 检查是否与玩家重合
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
        Debug.Log("Hit");
        
        yield return new WaitForSeconds(attackInterval);

        canAttack = true;
    }
}