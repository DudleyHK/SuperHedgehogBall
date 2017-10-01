using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float acceleration = 0.1f; //float between 0 and 1
    private Vector3 velocity;





    private void Awake()
    {
        var playerPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = playerPos;
    }




    private void FixedUpdate()
    {
        //Legacy Camera Movement
        //var playerPos = player.transform.position;
        //var newCamPos = new Vector3(playerPos.x, playerPos.y, this.transform.position.z);
        //transform.position = newCamPos;

        //Juicy Camera Movement
        velocity = (player.transform.position - this.transform.position) * acceleration;
        this.transform.Translate(velocity.x, velocity.y, 0);

    }
}