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
    float elapsed = 0;
    float time = 0;
    float miliseconds;

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
        UpdateTimer();
        UpdateScore();
        UpdateLives();
	}

    void UpdateTimer()
    {
        //elapsed = Time.deltaTime;
        time += Time.deltaTime;
        elapsed += Time.deltaTime;
        if(elapsed > 1)
        {
            elapsed = 0;
            miliseconds = 0;
        }
        
        miliseconds += Time.deltaTime * 100;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        timer.text = string.Format("{0}:{1}:{2}", minutes, seconds, miliseconds.ToString("00"));
    }

    void UpdateScore()
    {
        score.text = "" + PlayerData.Score.ToString();

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
