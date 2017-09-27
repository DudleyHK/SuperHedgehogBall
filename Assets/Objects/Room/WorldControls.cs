using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControls : MonoBehaviour
{
    public GameObject player;
    public float spinSpeed = 50f;


    private void Update()
    {
        var playerPosition = player.transform.position;
        


        // Rotate world object around player origin 
        if(Input.GetAxis("Horizontal") < 0)
        {
            //this.transform.RotateAround(transform.position, Vector3.forward, 200f * Time.deltaTime);
            transform.RotateAround(playerPosition, Vector3.forward, spinSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            //this.transform.RotateAround(transform.position, Vector3.back, 200f * Time.deltaTime);
            transform.RotateAround(playerPosition, Vector3.back, spinSpeed * Time.deltaTime);
        }
    }

}
