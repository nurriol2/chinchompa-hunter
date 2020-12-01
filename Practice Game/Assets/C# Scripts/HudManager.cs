using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text scoreLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    //show player stats in the HUD
    public void Refresh()
    {
        scoreLabel.text = "Score:  " + GameManager.instance.score;
    }
}
