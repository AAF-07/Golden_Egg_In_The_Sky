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


    // Start is called before the first frame update
    void Start()
    {
        loseui.SetActive(false);
        cam = Camera.main;
        if (camerafollow == null)
        {
            camerafollow = Camera.main != null ? Camera.main.transform : null;
        }
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnObstacle()
    {
        
    }

}
