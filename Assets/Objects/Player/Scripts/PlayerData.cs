using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //int lives = 1;
    private static int lives = 3;
    private static int score = 0;
    private static int highscore = 0;
    private static int bananaCount = 0;
    private static float speed = 0;



    public static int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }

    public static int HighScore
    {
        get
        {
            return highscore;
        }
        set
        {
            highscore = value;
        }
    }

    public static int BananaCount
    {
        get
        {
            return bananaCount;
        }
        set
        {
            bananaCount = value;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
}
