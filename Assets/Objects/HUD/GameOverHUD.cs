using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverHUD : MonoBehaviour {

    public Text finalScore;

	// Use this for initialization
	void Start () {
        setScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setScore()
    {
        finalScore.text = "" + PlayerData.getScore.ToString();
    }
}
