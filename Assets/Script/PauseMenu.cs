using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = true;


    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
