using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour {

	private AudioSource audioSource;
	private float timer = 0f;
	private bool big = false;
	public float scale = 0.5f;
	public float bounceMagnitude = 2.0f;
	private  Rigidbody2D rigidBody2D;

	void Start()
	{
		rigidBody2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		audioSource.Play();
		if (!big) 
		{
			transform.localScale += new Vector3 (0, scale, 0);
			big = true;
		}
	}

	private void Update ()
	{
		if (big)
		{
			if (timer <= 0.3f)
			{
				timer += Time.deltaTime;
				if (rigidBody2D.velocity.magnitude < bounceMagnitude) 
				{
					rigidBody2D.velocity += rigidBody2D.velocity.normalized;
				}
			} 
			else
			{
				timer = 0f;
				transform.localScale -= new Vector3 (0, scale, 0);
				big = false;
			}
		}
	}
}
