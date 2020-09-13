using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UIController : MonoBehaviour
{

    public Text scoreTXT;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Refresh()
    {
        scoreTXT.text = "Score: " + GameManager.instace.score;
    }
}
