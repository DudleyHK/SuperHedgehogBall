using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Text score;
    public Text timer;
    public Text speed;
    public GameObject[] livesSprites;
    float secondsPassed;
    int secondsTens = 0;
    int MinutesUnit = 0;
    int MinutesTens = 0;

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
        UpdateLives();
	}

    void UpdateTime()
    {
        secondsPassed += (Time.deltaTime);
        if (secondsPassed > 10)
        {
            secondsPassed = 0;
            secondsTens += 1;
            if(secondsTens > 5)
            {
                MinutesUnit += 1;
                secondsTens = 0;
            }
            if(MinutesUnit > 9)
            {
                MinutesUnit = 0;
                MinutesTens += 1;
            }
        }
        timer.text = MinutesTens.ToString() + MinutesUnit.ToString() + ":" + secondsTens.ToString() + (int) secondsPassed;
    }

    void UpdateScore()
    {
        //REPLACE WITH PLAYERS ACTUAL SCORE
        int playerScore = 1337;
        score.text = playerScore.ToString();
        
    }

    void UpdateLives()
    {
      //  int lives = 300;
      //  if(lives < 3)
      //  {
       //     if (livesSprites[lives].gameObject)
       //         Destroy(livesSprites[lives].gameObject);
       // }
    }

    void UpdateSpeed()
    {
        //REPLACE WITH PLAYER VELOCITY
        int speedos = 30;
        speed.text = speedos.ToString() + " mph";
    }
}
