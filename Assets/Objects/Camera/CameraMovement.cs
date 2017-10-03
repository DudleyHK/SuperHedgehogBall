using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float acceleration = 0.1f; //float between 0 and 1
    private Vector3 velocity;

    public float defaultCamZ = 3;
    public float camZ = 0.5f;
	public SceneIntro gameManager;

	public float camAcc;
	private float newCamSize;


	private bool started;


    private void Awake()
    {
      //  var playerPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
      //  transform.position = playerPos;
    }
		

    private void FixedUpdate()
    {
		if(SceneIntro.gameBegin)
		{
			//Legacy Camera Movement
			//var playerPos = player.transform.position;
			//var newCamPos = new Vector3(playerPos.x, playerPos.y, this.transform.position.z);
			//transform.position = newCamPos;

			//Juicy Camera Movement
			velocity = (player.transform.position - this.transform.position) * acceleration;
			this.transform.Translate (velocity.x, velocity.y, 0);

			//Juicy Camera Zooms
			//GetComponent<Camera>().orthographicSize = player.GetComponent<Rigidbody2D> ().velocity.magnitude * camZ + defaultCamZ;
			newCamSize = player.GetComponent<Rigidbody2D> ().velocity.magnitude * camZ + defaultCamZ;

			GetComponent<Camera>().orthographicSize += (newCamSize - GetComponent<Camera>().orthographicSize) * camAcc;

		}

    }
}