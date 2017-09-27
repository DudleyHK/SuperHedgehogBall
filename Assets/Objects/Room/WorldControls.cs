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





    private void Start()
    {
        currentAcceleration = normalAcceleration;
        currentMaxSpinVelocity = normalSpinVelocity;
    }


    private void FixedUpdate()
    {
        AddBoost();
        SpinRoom();
    }




    private void SpinRoom()
    {
        var playerPosition = player.transform.position;

        if (Input.GetAxis("Horizontal") < 0)
        {
            currentSpinVelocity += currentAcceleration;

            if (currentSpinVelocity >= currentMaxSpinVelocity)
            {
                currentSpinVelocity = currentMaxSpinVelocity;
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
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
            currentAcceleration = boostAcceleration;
            currentMaxSpinVelocity = boostSpinVelocity;
        }
        else
        {
            currentAcceleration = normalAcceleration;
            currentMaxSpinVelocity = normalSpinVelocity;
        }
    }
}
