using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //int lives = 1;
    public static int lives = 3;
    private static int score;
    private static int collectedBananas;
    float speed = 0;

    private GameObject player;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        player = gameObject;
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /**
          * Calculation of speed from velocity goes here
          **/
        if (collectedBananas >= 100)
        {
            modifyLives(1);
            collectedBananas -= 100;
        }
        Debug.Log(collectedBananas);
        speed = rigidBody.velocity.magnitude;
    }

    public static int getLives
    {
        get
        {
            return lives;
        }
    }

    public static int getBananas
    {
        get
        {
            return collectedBananas;
        }
    }

    public static int getScore
    {
        get
        {
            return score;
        }
    }

    public float getSpeed()
    {
        return speed;
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
