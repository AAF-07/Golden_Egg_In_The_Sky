using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject warningPrefab;
    public GameObject loseui;
    [Header("Time Settings")]
    public float spawnInterval = 3f;
    public float warningTime = 1.5f;
    [Header("Spawn Area Settings")]
    public float warningoffsety = 1f;
    public float kacangoffsety = 3f;
    [Header("Reference")]
    public Transform camerafollow;

    private Camera cam;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        loseui.SetActive(false);
        cam = Camera.main;
        if (camerafollow == null)
        {
            camerafollow = Camera.main != null ? Camera.main.transform : null;
        }
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnObstacle()
    {
        float halfwidth = cam.orthographicSize * cam.aspect;
        float randomx = Random.Range(cam.transform.position.x - halfwidth, cam.transform.position.x + halfwidth);
        StartCoroutine(SpawnWarning(randomx));
    }

    IEnumerator SpawnWarning(float x)
    {
        float z = warningPrefab != null ? warningPrefab.transform.position.z : 0f;
        if (obstaclePrefab != null)
        {
            z = obstaclePrefab.transform.position.z;
        }

        float camz = Mathf.Abs(cam.transform.position.z);
        Vector3 topworld = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, camz));
        float topy = topworld.y;

        Vector3 warningpos = new Vector3(x, topy - warningoffsety, z);
        GameObject warning = Instantiate(warningPrefab, warningpos, Quaternion.identity);

        float t = 0f;
        while (t < warningTime)
        {
            float loopTopy = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, camz)).y;
            warning.transform.position = new Vector3(x, loopTopy - warningoffsety, warning.transform.position.z);

            t += Time.deltaTime;
            yield return null;
        }

        Destroy(warning);

        float kacangY = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, camz)).y - kacangoffsety;
        Vector3 kacangpos = new Vector3(x, kacangY + kacangoffsety, z);
        Instantiate(obstaclePrefab, kacangpos, Quaternion.identity); 

    }

    void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (scoreManager != null)
            {
                Debug.Log("ada score");
                scoreManager.ShowFinalScore();
            }
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }

}
