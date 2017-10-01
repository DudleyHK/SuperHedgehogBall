using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody2D playerRigidbody;
    public float timer = 0f;


    // Update is called once per frame
    private void Update ()
    {
       AnimatorStateInfo stateInfo = playerAnim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Idle"))
        {
            if (timer <= 10f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                playerAnim.SetBool("Blink", true);
                timer = 0f;
            }
        }
        else if (stateInfo.IsName("Blink"))
        {
            if(stateInfo.normalizedTime >= 2f)
            {
                playerAnim.SetBool("Blink", false);
            }
            Debug.Log("Normalised Blink Time: " + stateInfo.normalizedTime);
        }
        playerAnim.SetFloat("Speed", playerRigidbody.velocity.magnitude);
	}
}





 // AnimatorStateInfo stateInfo = playerAnim.GetCurrentAnimatorStateInfo(0);
// if (!paused)
            // {
                // currentWaitTime = Random.Range(MIN_WAIT_TIME, MAX_WAIT_TIME);
                // paused = true;
            // }
            // else
            // {
                // if (timer <= currentWaitTime)
                // {
                    // timer += Time.deltaTime;
                // }
                // else
                // {
                    // timer = 0f;
                    // paused = false;
                // }
            // }
