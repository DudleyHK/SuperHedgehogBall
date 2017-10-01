using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath : MonoBehaviour
{
    public GameObject killBox;
    PlayerData playerData;

    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == killBox)
        {
            LevelManager.ResetScene();
            playerData.modifyLives(-1);
        }
    }
}
