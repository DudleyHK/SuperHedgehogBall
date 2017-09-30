using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour {

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	/*void OnTriggerEnter2D(Collider2D col)
	{
		audioSource.Play();
	}*/
	void OnCollisionEnter2D(Collision2D col)
	{
		//if (collision.relativeVelocity.magnitude > 2)
			audioSource.Play();
	}
}
