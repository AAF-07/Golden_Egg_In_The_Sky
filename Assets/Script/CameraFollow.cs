using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
    }
}
