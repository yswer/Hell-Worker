using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 对敌人造成伤害的逻辑
            // 例如：调用敌人脚本的伤害函数
            // collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

            // 销毁子弹
            Destroy(gameObject);
        }
    }
}