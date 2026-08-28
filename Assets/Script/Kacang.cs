using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kacang : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed * Time.deltaTime;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (scoreManager != null)
            {
                scoreManager.ShowFinalScore();
            }
            else
            {
                Debug.Log("Ga Kedetect");
            }
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Void"))
        {
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player"))
        {
            return;
        }
    }
}
