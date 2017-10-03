using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    public bool grounded = false;
    public float threshold = 5f;
    public AudioClip hitFloor;
    public AudioClip smashFloor;
    private CameraShake camShake { get { return Camera.main.GetComponent<CameraShake>(); } }



    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name != "KillBox")
        {
            if (!grounded)
            {
                if(PlayerData.Speed > threshold)
                {
                    camShake.ShakeCamera(0.5f, .1f);
                    SmashFloor();
                }
                else
                {
                    HitFloor();
                }
                    

                grounded = true;
                HitFloor();
            }
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }

    private void SmashFloor()
    {
        if (!source.isPlaying)
        {
            source.clip = smashFloor;
            source.PlayOneShot(smashFloor);

        }
        Debug.Log("Smash Floor");
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
