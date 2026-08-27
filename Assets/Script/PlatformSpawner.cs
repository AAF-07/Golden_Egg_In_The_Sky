using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public int platformcount = 1000;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < platformcount; i++)
        {
            GameObject PlatformToSpawn;

            if (Random.value < 0.7f)
            {
                PlatformToSpawn = platformPrefab[Random.Range(0, 2)];
            }
            else
            {
                PlatformToSpawn = platformPrefab[Random.Range(2, 4)];
            }

            spawnPosition.y += Random.Range(2f, 2.5f);
            spawnPosition.x = Random.Range(-3f, 3f);
            Instantiate(PlatformToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
