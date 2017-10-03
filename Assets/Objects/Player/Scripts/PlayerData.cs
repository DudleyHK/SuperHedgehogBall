using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //int lives = 1;
    private static int lives = 3;
    private static int score;
    private static int collectedBananas;
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

    public static int Bananas
    {
        get
        {
            return collectedBananas;
        }
        set
        {
            collectedBananas = value;
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
    
    public void modifyLives(int amount)
    {
        lives += amount;
    }

    public void modifyScore(int amount)
    {
        score += amount;
    }

    public void modifyBananas(int amount)
    {
        collectedBananas += amount;
    }
}
