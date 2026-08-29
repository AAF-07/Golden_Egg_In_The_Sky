using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameover = false;

    public GameObject loseui;
    public GameObject pauseui;
    public GameObject confirmPanel;

    public static GameManager Instance { get; private set; }
    private bool confirmFromGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (confirmPanel != null)
        {
            confirmPanel.SetActive(false);
        }

        if (loseui != null)
        {
            loseui.SetActive(false);
        }

        if (pauseui != null)
        {
            pauseui.SetActive(false);
        }

        Time.timeScale = 1f;
        gameover = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameover)
                return;

            if (confirmPanel != null && confirmPanel.activeSelf)
            {
                CloseConfirmPanel();
                return;
            }

            TogglePause();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameover = false;

        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        gameover = false;

        SceneManager.LoadScene("Main Menu");
    }

    public void GameOver()
    {
        gameover = true;

        if (loseui != null)
        {
            loseui.SetActive(true);
        }

        if (pauseui != null)
        {
            pauseui.SetActive(false);
        }

        if (confirmPanel != null)
        {
            confirmPanel.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    public void TogglePause()
    {
        if (gameover)
            return;

        bool isPaused = !pauseui.activeSelf;

        if (pauseui != null)
        {
            pauseui.SetActive(isPaused);
        }

        if (confirmPanel != null)
        {
            confirmPanel.SetActive(false);
        }

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void OpenConfirmPanel()
    {
      
        confirmFromGameOver = gameover;

        if (pauseui != null)
        {
            pauseui.SetActive(false);
        }

        if (loseui != null)
        {
            loseui.SetActive(false);
        }

        if (confirmPanel != null)
        {
            confirmPanel.SetActive(true);
        }
    }

    public void CloseConfirmPanel()
    {
        if (confirmPanel != null)
        {
            confirmPanel.SetActive(false);
        }

        if (confirmFromGameOver)
        {
            if (loseui != null)
            {
                loseui.SetActive(true);
            }

            if (pauseui != null)
            {
                pauseui.SetActive(false);
            }
        }
        else
        {
            if (pauseui != null)
            {
                pauseui.SetActive(true);
            }

            if (loseui != null)
            {
                loseui.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}