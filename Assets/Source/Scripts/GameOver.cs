using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        score.text = GameManager.instace.score.ToString();
        highScore.text = GameManager.instace.highScore.ToString();
    }

    public void RestartKuy()
    {
        SceneManager.LoadScene("Home");
    }
    
}
