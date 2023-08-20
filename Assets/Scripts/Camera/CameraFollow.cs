using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 玩家的 Transform
    public float smoothSpeed = 0.01f;
    public Vector3 offset;

    private float originalZ;

    void Start()
    {
        originalZ = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = originalZ; // 设置相机的 z 坐标

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // transform.LookAt(target);
    }
}