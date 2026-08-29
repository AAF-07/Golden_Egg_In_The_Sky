using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggController : MonoBehaviour
{
    private Collider2D myCollider;
    private SpriteRenderer myRenderer;

    void Start()
   {
        myCollider = GetComponent<Collider2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }

            Debug.Log("player hit egg");

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.playcollect();
            }

            if (myRenderer != null) myRenderer.enabled = false;
            if (myCollider != null) myCollider.enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }
}