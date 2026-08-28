using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text finalScoreText;

    private int score = 0;
    private int highScore = 0;
    private int lastHighScore = 0;
    private bool newHighScore = false;  
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
        if (score > highScore)
        {
            highScore = score;
            newHighScore = true;
            highScoreText.text = "High Score: " + highScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            Debug.Log("New High Score: " + highScore);
        }
    }

    public void SaveLastScore()
    {
        lastHighScore = score;
        PlayerPrefs.SetInt("LastHighScore", lastHighScore);
        PlayerPrefs.Save();
        Debug.Log("Last Score Saved: " + lastHighScore);
    }
    
    public void ShowFinalScore()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = GetCurrentScore().ToString();
        }
    }
    public int GetCurrentScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public int GetLastHighScore()
    {
        return lastHighScore;
    }

    public bool IsNewHighScore()
    {
        return newHighScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        lastHighScore = PlayerPrefs.GetInt("LastHighScore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
