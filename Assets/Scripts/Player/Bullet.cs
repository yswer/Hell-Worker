using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10;
    public float lifespan = 5.0f; // 子弹的寿命，单位为秒

    private float startTime;

    void Start()
    {
        startTime = Time.time; // 记录子弹生成的时间
    }

    void Update()
    {
        // 检查子弹是否达到寿命，如果是则销毁
        if (Time.time - startTime >= lifespan)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 对敌人造成伤害的逻辑
            // 例如：调用敌人脚本的伤害函数
            // collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyController>().health -= damage;
            // 销毁子弹
            Destroy(gameObject);
        }
        else
        {
            var rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 normal = collision.contacts[0].normal;
            Vector2 newDirection = Vector2.Reflect(rb.velocity.normalized, normal);
            rb.velocity = newDirection * rb.velocity.magnitude;
        }
    }
}