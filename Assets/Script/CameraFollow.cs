using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform background;

    public float smoothSpeed = 0.125f;

    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            FollowTarget();
        }

        if (background != null)
        {
            background.position = new Vector3(
                background.position.x,
                transform.position.y,
                background.position.z
            );
        }
    }

    void FollowTarget()
    {
        Vector3 newPosition = new Vector3(
            transform.position.x,
            target.position.y,
            transform.position.z
        );

        transform.position = Vector3.Slerp(
            transform.position,
            newPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}