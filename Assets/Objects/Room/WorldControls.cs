using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControls : MonoBehaviour
{
    public GameObject player;

    public float currentSpinVelocity    = 0f;
    public float currentMaxSpinVelocity = 0f;
    public float normalSpinVelocity     = 75f;
    public float boostSpinVelocity      = 150f;

    public float currentAcceleration = 0f;
    public float normalAcceleration = 1f;
    public float boostAcceleration = 2f;
    
    public float drag = 0.5f;
    public bool boostLock = false;

    public AudioClip mapBoost;

    private AudioSource source { get { return this.GetComponent<AudioSource>(); } }




    private void Start()
    {
        player = GameObject.Find("Player");
        currentAcceleration = normalAcceleration;
        currentMaxSpinVelocity = normalSpinVelocity;
    }


    private void FixedUpdate()
    {
        if (!SceneIntro.gameBegin) return;
        AddBoost();
        SpinRoom();
    }




    private void SpinRoom()
    {
        var playerPosition = player.transform.position;

        if (Input.GetAxis("Horizontal") < 0)
        {
            if(currentSpinVelocity < 0)
            {
                currentSpinVelocity = 0;
            }

            currentSpinVelocity += currentAcceleration;

            if (currentSpinVelocity >= currentMaxSpinVelocity)
            {
                currentSpinVelocity = currentMaxSpinVelocity;
            }
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            LevelManager.LoadScene("LevelSelector");
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if(currentSpinVelocity > 0)
            {
                currentSpinVelocity = 0;
            }

            currentSpinVelocity -= currentAcceleration;

            if (currentSpinVelocity <= -currentMaxSpinVelocity)
            {
                currentSpinVelocity = -currentMaxSpinVelocity;
            }
        }
        else
        {
            if (currentSpinVelocity < 0)
            {
                currentSpinVelocity += drag;

                if (currentSpinVelocity > 0)
                    currentSpinVelocity = 0;
            }
            else if (currentSpinVelocity > 0)
            {
                currentSpinVelocity -= drag;

                if (currentSpinVelocity < 0)
                    currentSpinVelocity = 0;
            }
        }
        transform.RotateAround(playerPosition, Vector3.forward, currentSpinVelocity * Time.deltaTime);
    }



    private void AddBoost()
    {
        if (Input.GetAxis("Triggers") < 0)
        {
            if (!boostLock)
            {
                currentAcceleration = boostAcceleration;
                currentMaxSpinVelocity = boostSpinVelocity;

                if (!source.isPlaying)
                {
                    source.clip = mapBoost;
                    source.PlayOneShot(mapBoost);
                }

                boostLock = true;
                StartCoroutine(SetBackToNormal());
            }
        }
        else
        {
            boostLock = false;
            currentAcceleration = normalAcceleration;
            currentMaxSpinVelocity = normalSpinVelocity;
        }
    }


    private IEnumerator SetBackToNormal()
    {
        while(source.isPlaying)
        {
            yield return false;
        }

        currentAcceleration = normalAcceleration;
        currentMaxSpinVelocity = normalSpinVelocity;
        yield return true;
    }
}
