using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewGameOver : MonoBehaviour
{
    [SerializeField]
    private NewGameManager gm;

    public Text txtScore;
    public Text txtHighScore;

    // Start is called before the first frame update
    void Start()
    {
        GameOverUi();
    }

    public void GameOverUi()
    {
        txtScore.text = gm.score.ToString();
        txtHighScore.text = gm.highScore.ToString();
    }

    public void btnBack()
    {
        gm.Reset();
    }

}
