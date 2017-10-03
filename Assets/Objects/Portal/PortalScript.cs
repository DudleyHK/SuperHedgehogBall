using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{

    public GameObject player;
    public GameObject direction;
    public GameObject spawn;
    public PortalScript twin;

    private float speed = 1000.0f;

    public bool sw1tch;

    private Vector2 dirPos;
    private Vector2 spaPos;
    private Vector2 plaPos;

    private PortalScript script;
    private Rigidbody2D rb;

    private AudioSource source { get { return this.GetComponent<AudioSource>(); } }


    // Use this for initialization
    void Start ()
    {
        sw1tch = true;
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
    }

   // IEnumerator OnTriggerEnter2D(Collider2D other)
    //{
    //    if (sw1tch == true)
    //    {
    //        //GetComponentInChildren<BoxCollider2D>().enabled = false;
    //        //yield return new WaitForSeconds(2);
    //        player.transform.position = spawn.transform.position;
    //        rb.AddForce(direction.transform.up * speed);
    //        //player.transform.LookAt(dirPos);
    //        //rb.AddForce(transform.forward * speed);

    //        sw1tch = false;
    //        //yield return new WaitForSeconds(1);
    //        sw1tch = true;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = twin.spawn.transform.position;
        rb.AddForce(twin.direction.transform.up * speed);

        // Play Portal Audio
        if (!source.isPlaying)
            source.Play();
    }
}
