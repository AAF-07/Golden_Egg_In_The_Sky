using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
      Debug.Log("Player has Exit Game");
        Application.Quit();
    }

    public void QuitToMenu()
    {
        Debug.Log("PLayer has quit to Menu");
        SceneManager.LoadScene("MainMenu");
    }

    
    void Update()
    {
        
    }
}
