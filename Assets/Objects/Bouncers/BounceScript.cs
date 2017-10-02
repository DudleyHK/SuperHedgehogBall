using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour {

	public AudioSource audioSource;
	public float timer = 0f;
	public bool big = false;
	public int scale = 5;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		audioSource.Play();
		if (!big) 
		{
			transform.localScale += new Vector3 (scale, scale, scale);
			big = true;
		}
	}

	private void Update ()
	{
		if (big)
		{
			if (timer <= 0.5f)
			{
				timer += Time.deltaTime;
			} 
			else
			{
				timer = 0f;
				transform.localScale -= new Vector3 (scale, scale, scale);
				big = false;
			}
		}
	}
}
