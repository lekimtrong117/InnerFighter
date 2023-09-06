using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDownCamera : MonoBehaviour
{
    public Transform trans;
    public Transform target_to_follow;
    public Vector3 camera_offset;
    public float camera_speed = 100;
    private void Awake()
    {
        trans = transform;
    }

    private void LateUpdate()
    {
        trans.position = Vector3.Lerp(trans.position, target_to_follow.position + camera_offset,Time.deltaTime*camera_speed);
    }
}
