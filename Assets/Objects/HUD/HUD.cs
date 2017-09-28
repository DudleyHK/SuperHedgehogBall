using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Text score;
    public Text timer;
    public Text speed;
    float elapsed;
    float secondsPassed;
    
    // Use this for initialization
    void Start()
    {
        score.text = "S C O R E";
        timer.text = "T I M E";
        speed.text = "S P E E D";
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSpeed();
        UpdateTime();
        UpdateScore();
	}

    void UpdateTime()
    {
        elapsed += (Time.deltaTime);
        secondsPassed += (Time.deltaTime);
        //displayTime(); //Displays the time
    }

    void UpdateScore()
    {
        //REPLACE WITH PLAYERS ACTUAL SCORE
        int playerScore = 1337;
        score.text = playerScore.ToString();
        
    }

    void UpdateSpeed()
    {
        int speedos = 30;
        speed.text = speedos.ToString() + " mph";
    }
}
