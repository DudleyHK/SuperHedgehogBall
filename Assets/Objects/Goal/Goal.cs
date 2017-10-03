using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public HUD hud;
    public WorldControls room;
    public float finalTime;
    public float endRotSpeed = 500;

    public float fullEndTime    = 1;
    public float endTimer      = 0;

    private GameObject player;

    public bool ended;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(ended)
        {
            room.transform.RotateAround(player.transform.position, Vector3.forward, Time.deltaTime * endRotSpeed);
            endTimer += Time.deltaTime;
            if(endTimer >= fullEndTime)
            {
                LevelManager.LoadScene("LevelOne");
                Debug.Log("Level Complete");
            }


        }
	}

    void OnTriggerEnter2D(Collider2D _player)
    {
        if(_player.gameObject.name == "Player")
        {
            player = _player.gameObject;
            Debug.Log("Reached Goal");
            finalTime = hud.getElapsed();
            Debug.Log(finalTime.ToString());
            _player.transform.position = this.transform.position;
            _player.GetComponent<Rigidbody2D>().gravityScale = 0;
            _player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ended = true;

            GetComponent<ParticleSystem>().Play();
        }
    }
}
