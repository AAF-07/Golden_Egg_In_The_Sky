using System.Collections;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public float jumpforce = 10f;
    public bool platformstay = true;

    private Renderer platformrenderer;


    void Start()
    {
        platformrenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
                AudioManager.Instance.playjump();
            }

            
            if (!platformstay)
            {
                StartCoroutine(FadeAndDestroy());
            }
        }
    }

    private IEnumerator FadeAndDestroy()
    {
        
        yield return new WaitForSeconds(0.5f);

        float startAlpha = platformrenderer.material.color.a;
        float targetAlpha = 0f;
        float duration = 0.1f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(
                startAlpha,
                targetAlpha,
                elapsedTime / duration
            );

            Color newColor = platformrenderer.material.color;
            newColor.a = newAlpha;
            platformrenderer.material.color = newColor;

            yield return null;
        }

       
        Color finalColor = platformrenderer.material.color;
        finalColor.a = 0f;
        platformrenderer.material.color = finalColor;

        Destroy(gameObject);
    }
}