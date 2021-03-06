﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : ScriptableObject
{

    /*default is current scene.
     enter name for to start another scene.*/
    public static void ResetScene() { ResetScene(SceneManager.GetActiveScene().name); }
    public static void ResetScene(string name) 
    {
        LoadScene(name);

        // Fire off event here. Instead hack it in..
        PlayerData.BananaCount = 0;
        PlayerData.Score = 0;
        PlayerData.Lives = 3;
    }
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static void LoadScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
	
}
