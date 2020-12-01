using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    //event on button press
    public void StartGame()
    {
        //Load a Scene - sensitive to Scene name (string)
        SceneManager.LoadScene("Level 1");
    }
}