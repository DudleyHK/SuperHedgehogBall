﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverHUD : MonoBehaviour {

    public Text finalScore;
    public Text highScore;

	// Use this for initialization
	void Start () {
        setScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setScore()
    {
        finalScore.text = "You collected " + PlayerData.Score.ToString() + " bananas";
        highScore.text = "Your highscore is " + PlayerData.HighScore.ToString() + " bananas";
    }
}
