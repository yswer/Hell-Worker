using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

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
}