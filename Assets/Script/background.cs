using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject bg;
    public float loop = 100;
    public float heightbg = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = Vector3.zero;
        for(int i = 0; i < loop; i++)
        {
            spawnPosition.y += heightbg;
            Instantiate(bg, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
