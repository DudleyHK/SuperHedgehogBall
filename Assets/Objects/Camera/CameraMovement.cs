using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;


	private void Update ()
    {
        var playerPos = player.transform.position;
        var newCamPos = new Vector3(playerPos.x, playerPos.y, this.transform.position.z);
        transform.position = newCamPos;
    }
}
