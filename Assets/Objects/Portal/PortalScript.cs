using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    public GameObject player;
    public GameObject direction;
    public GameObject spawn;

    private float speed = 5.0f;

    private Vector2 dirPos;
    private Vector2 spaPos;
    private Vector2 plaPos;

    // Use this for initialization
    void Start () {
        plaPos = player.transform.postition;
        spaPos = spawn.transform.position;
        dirPos = direction.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        plaPos = Vector2.MoveTowards(spaPos, dirPos, speed * Time.deltaTime);
    }
}
