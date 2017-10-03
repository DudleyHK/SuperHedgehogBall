using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody2D playerRigidbody;
    public float timer = 0f;

    public AudioSource source;

    public SpriteRenderer lifeSprite;
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
            PlayerData.Score += 1;
            PlayerData.BananaCount += 1;
            if (PlayerData.Score > PlayerData.HighScore)
                PlayerData.HighScore = PlayerData.Score;
            other.gameObject.GetComponent<BananaCollectable>().DestroyBanana();
            //StartCoroutine(addLife());
        }
    }


    private void CheckBananaScore()
    {
        if (PlayerData.BananaCount >= 10)
        {
            PlayerData.Lives++;
            PlayerData.BananaCount -= 100;
            StartCoroutine(addLife());
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
              //  source.Play();
            }
        }
        else
        {
            source.Stop();
        }
        playerAnim.SetFloat("Speed", playerRigidbody.velocity.magnitude);
    }

    IEnumerator addLife()
    {
        lifeSprite.enabled = true;
        yield return new WaitForSeconds(2); //However many seconds you want
        lifeSprite.enabled = false; //This toggles it
    }
}

