using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject confirmPanel;
   public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        confirmPanel.SetActive(true);
    }

    public void QuitToMenu()
    {
        Debug.Log("PLayer has quit to Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Debug.Log("Player has Exit Game");
        Application.Quit();
    }

    public void Cancel()
    {
        confirmPanel.SetActive(false);
    }

    void Start()
    {
        confirmPanel.SetActive(false);
    }
    
    void Update()
    {
        
    }
}
