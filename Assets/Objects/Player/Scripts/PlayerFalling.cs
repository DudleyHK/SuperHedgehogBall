using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    public bool grounded = false;
    public AudioClip hitFloor;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }




    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name != "KillBox")
        {
            if (!grounded)
            {
                grounded = true;
                HitFloor();
            }
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }


    private void HitFloor()
    {
        if(!source.isPlaying)
        {
            source.clip = hitFloor;
            source.PlayOneShot(hitFloor);
        }
        Debug.Log("Hit Floor");
    }
}
