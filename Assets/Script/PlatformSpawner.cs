using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public int platformcount = 1000;
    public float Xdistance = 3.5f;
    public float minPosX = -3.5f;
    public float maxPosX = 3.5f;

    void Start()
    {
        Vector3 spawnPosition = Vector3.zero;
        float lastPosX = 0f;

        for (int i = 0; i < platformcount; i++)
        {
            GameObject platformToSpawn;

            if (Random.value < 0.7f)
            {
                platformToSpawn = platformPrefab[Random.Range(0, 2)];
            }
            else
            {
                platformToSpawn = platformPrefab[Random.Range(2, 4)];
            }

    
            spawnPosition.y += 2f;

            float newPosX;
            do
            {
                newPosX = Random.Range(minPosX, maxPosX);
            }
            while (Mathf.Abs(newPosX - lastPosX) < Xdistance);

            spawnPosition.x = newPosX;
            lastPosX = newPosX;

            Instantiate( platformToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
