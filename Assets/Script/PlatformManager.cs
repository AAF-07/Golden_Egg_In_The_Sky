using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public float jumpforce = 10f;
    public bool platformstay = true;
    public float speed = 1f;

    public void OntriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f && platformstay == true)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
            }
        }else if(collision.relativeVelocity.y <= 0f && platformstay == false)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
            }
            StartCoroutine(waitforseconds(1f));
        }

    }
    private IEnumerator waitforseconds(float v)
    {
        yield return new WaitForSeconds(v);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
