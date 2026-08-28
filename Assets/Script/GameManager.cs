using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameover = false;
    public GameObject loseui;
    public static GameManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameover = true;
        loseui.SetActive(true);
        Time.timeScale = 0f;
    }
}
