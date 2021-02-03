using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField] [Range(0.01f, 1f)]

    private float smoothSpeed = 0.125f;

    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

    }
}
