using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsContraints : MonoBehaviour {

    public  float       maxSpeed;
    public  bool        isBoosting;
    public  Rigidbody2D rigidBody2D;
    private float       boostTimer;
    private float       defaultBoostTime = 0;

	// Use this for initialization
	void Start ()
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!isBoosting)
        {
            if(rigidBody2D.velocity.magnitude > maxSpeed)
            {
                rigidBody2D.velocity = rigidBody2D.velocity.normalized * maxSpeed;
            }
        }

        if(isBoosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer > defaultBoostTime)
            {
                isBoosting = false;
            }
        }

	}

    void boost(float boostTime = defaultBoostTime)
    {
        isBoosting = true;
        boostTimer = 0;
    }

}
