using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody2D playerRigidbody;
    public float timer = 0f;

    public AudioSource source;




    // Update is called once per frame
    private void Update()
    {
        PlayerData.Speed = playerRigidbody.velocity.magnitude;
        AnimationUpdate();
        CheckBananaScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Banana")
        {
            PlayerData.Score += 10;
            PlayerData.Bananas += 10;
            other.gameObject.GetComponent<BananaCollectable>().DestroyBanana();
        }
    }


    private void CheckBananaScore()
    {
        if (PlayerData.Bananas >= 100)
        {
            PlayerData.Lives++;
            PlayerData.Bananas -= 100;
        }
    }

    private void AnimationUpdate()
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
            if (stateInfo.normalizedTime >= 2f)
            {
                playerAnim.SetBool("Blink", false);
            }
        }

        if (stateInfo.IsName("Rolling"))
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }
        playerAnim.SetFloat("Speed", playerRigidbody.velocity.magnitude);
    }

}

