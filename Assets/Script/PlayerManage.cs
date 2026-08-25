using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private float moveX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * speed;
        rb.velocity = velocity;
    }
}
