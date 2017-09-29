using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    public GameObject player;
    public GameObject direction;
    public GameObject spawn;

    private float speed = 5.0f;

    public bool sw1tch;

    private Vector2 dirPos;
    private Vector2 spaPos;
    private Vector2 plaPos;

    private PortalScript script;

    // Use this for initialization
    void Start () {
        sw1tch = true;
    }
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (sw1tch == true)
        {
            GetComponentInChildren<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(2);
            player.transform.position = spawn.transform.position;

            sw1tch = false;
            yield return new WaitForSeconds(6);
            sw1tch = true;
        }
        //will think of better timer later
    }

    void Teleport()
    {

    }
}
