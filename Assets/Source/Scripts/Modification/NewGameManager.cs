using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{
    public int score = 1;
    public int highScore = 10;


    int currentLevel = 1;
    int highestLevel = 2;

    
    public Text txtScore, txtScoreUI, txtHighScore;

    private void Start()
    {
        RefreshScoreUI();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("gameOver");
    }

 
    public void IncreceScoring(int value)
    {
        //menyimpan nilai score
        score += value;

        // update nilai highscore terbaru
        if (score > highScore)
        {
            highScore = score;

            Debug.Log("New Score :" + highScore);
        }
        Debug.Log("Score" + score.ToString());

    }

    public void IncreseLevel()
    {
        if (currentLevel < highestLevel)
        {
            currentLevel++;
            Debug.Log("Level Sekarang " + currentLevel);
        }
        else
        {
            currentLevel = 1;
        }

        SceneManager.LoadScene("Level" + currentLevel);
        Debug.Log("Level Sekarang " + currentLevel);
    }

    public void RestartToHome()
    {
        SceneManager.LoadScene("Home");
        Debug.Log("Yey DiHome");
    }

    public void RefreshScoreUI()
    {
        txtScoreUI.text = "Score: " + score;
    }

    public void Reset()
    {
        score = 0;
        currentLevel = 1;

        SceneManager.LoadScene("Level" + currentLevel);

        Debug.Log("Yey Tereset");
    }

}
