using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace = null;

    public int score = 0;
    public int highScore = 5;
    public int currentLevel = 1;
    public int highestLevel = 2;

    // Start is called before the first frame update
    void Awake()
    {

        if (instace == null)
        {
            instace = this;
        }
        else if (instace != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }


    public void IncreceScoring (int amount) 
    {
        score += amount;

        if( score > highScore)
        {
            highScore = score;
            print("New Score " + highScore);

        }

        print("New Score " + score.ToString());
        Debug.Log("New Score " + score.ToString());
    }

    public void Reset()
    {
        score = 0;
        currentLevel = 1;

        SceneManager.LoadScene("Level" + currentLevel);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }


    public void IncreseLevel()
    {
        if (currentLevel < highestLevel)
        {
            currentLevel++;
        }
        else
        {
            currentLevel = 1;
        }

        SceneManager.LoadScene("Level" + currentLevel);
    }

}
