using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

    private PlayerData playerData;
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
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
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
        score.text = playerData.getScore().ToString();
        
    }

    void UpdateLives()
    {
        if( playerData.getLives() < 3)
        {
            if (livesSprites[playerData.getLives()].gameObject)
                Destroy(livesSprites[playerData.getLives()].gameObject);
        }
    }

    void UpdateSpeed()
    {
        speed.text = (int) playerData.getSpeed() + " mph";
    }
}
