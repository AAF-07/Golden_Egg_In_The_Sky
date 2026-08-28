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
    // Start is called before the first frame update

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
            if (gameover) return;
            if (confirmPanel != null && confirmPanel.activeSelf)
            {
                CloseConfirmPanel();
                return;
            }

            if (!gameover)
            {
                TogglePause();
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        gameover = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        gameover = false;
    }
    public void GameOver()
    {
        gameover = true;
        loseui.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TogglePause()
    {
        bool isPaused = !pauseui.activeSelf;
        pauseui.SetActive(isPaused);

        if (confirmPanel != null)
        {
            confirmPanel.SetActive(false);
        }
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void OpenConfirmPanel()
    {
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
