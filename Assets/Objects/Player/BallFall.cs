using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ballPos = this.transform.position;
        ballPos.y -= 0.05f;
        this.transform.position = ballPos;
	}
}
