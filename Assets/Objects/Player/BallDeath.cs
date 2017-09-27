using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath : MonoBehaviour
{
    public GameObject killBox;




    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == killBox)
        {
            LevelManager.ResetCurrentScene();
        }
    }
}
