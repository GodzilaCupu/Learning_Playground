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
    }


    public void IncreseLevel(int lvl)
    {
        currentLevel += lvl;
        if (currentLevel <= highestLevel)
        {
            SceneManager.LoadScene("Level"+currentLevel);
        }else if ( currentLevel > highestLevel)
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }

    }
}
