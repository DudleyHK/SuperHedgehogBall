using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour {

	private AudioSource audioSource;
	private float timer = 0f;
	private bool big = false;
	public float scale = 5f;
	private  Rigidbody2D rigidBody2D;
	public float bounceMagnitude = 3.0f;
	public Sprite idleSprite; 
	public Sprite bigSprite; 
	private SpriteRenderer spriteRenderer; 

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		rigidBody2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		spriteRenderer = this.GetComponent<SpriteRenderer>(); 
		if (spriteRenderer.sprite == null)
		{
		//	spriteRenderer.sprite = idleSprite; 
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		audioSource.Play();
		if (!big) 
		{
			transform.localScale += new Vector3 (scale, scale, scale);
			//rigidBody2D = col.gameObject.GetComponent<Rigidbody2D>();
			big = true;
		}
	}

	private void Update ()
	{
		if (big)
		{
			spriteRenderer.sprite = bigSprite;
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
				transform.localScale -= new Vector3 (scale, scale, scale);
				big = false;
			}
		}
		else
		{
			spriteRenderer.sprite = idleSprite;
		}
	}
}
