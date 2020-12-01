using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    //static instance of game manager
    //acessible anywhere
    public static GameManager instance = null;

    //player score
    public int score = 0;

    //high score
    public int highScore = 0;

    //current level
    public int currentLevel = 1;

    //highest possible level
    public int highestLevel = 2; 

    //called when object is initialized
    void Awake()
    {
        //if no game manager object exists yet
        if (instance==null)
        {
            //set the instance to the current object (basically self)
            instance = this;
        }

        //using singleton pattern so check that there is only 1 game manager
        else if (instance!=this)
        {
            //destroy the current object so there is just 1 manager
            Destroy(gameObject);
        }

        //do not destroy this object when loading scenes
        DontDestroyOnLoad(gameObject);
    }

    //increase score
    public void IncreaseScore(int amount)
    {
        //increase the player score
        score += amount;

        print("New Score " + score.ToString());

        //check the high score
        if(score > highScore)
        {
            //update the new high score
            highScore = score;
            print("New High Score! " + highScore.ToString());
        }
    }

    //restart the game
    public void Reset()
    {
        //refresh score
        score = 0;

        //set level back to 1
        currentLevel = 1;

        //Load corresponding scene 
        SceneManager.LoadScene("Level " + currentLevel.ToString());
    }

    public void IncreaseLevel()
    {
        if (currentLevel<highestLevel)
        {
            currentLevel++;
        }
        else
        {
            currentLevel = 1;
        }

        SceneManager.LoadScene("Level " + currentLevel.ToString());
    }

}
