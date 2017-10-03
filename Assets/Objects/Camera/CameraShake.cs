using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTimer = 0f;
    public float shakeAmount = 0f;


	void Start ()
    {
		
	}
	
	void Update ()
    {
	    if(shakeTimer >= 0f)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);


            shakeTimer -= Time.deltaTime;
        }
	}


    public void ShakeCamera(float shakeAmount, float shakeDuration)
    {
        this.shakeAmount = shakeAmount;
        this.shakeTimer = shakeDuration;
    }
}
