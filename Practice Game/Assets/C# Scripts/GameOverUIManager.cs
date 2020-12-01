using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    //variables to store values from GameManager instance
    public Text score;
    public Text highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        //set the visible text to values grabbed from the game instance
        score.text = GameManager.instance.score.ToString();
        highScore.text = GameManager.instance.highScore.ToString();
    }

    public void RestartGame()
    {
        //use the Reset method found in GameManager
        GameManager.instance.Reset();
    }
}
