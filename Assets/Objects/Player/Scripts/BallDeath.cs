using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath : MonoBehaviour
{
    public GameObject killBox;
    public AudioClip die;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void Start()
    {
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == killBox)
        {
            if (!source.isPlaying)
            {
                source.clip = die;
                source.PlayOneShot(die);
            }

            print("leaving kill box");
            StartCoroutine(WaitForSoundBeforeSceneChange());
            if(PlayerData.Lives > 0)
            {
                PlayerData.Lives = -1;
            }
            else
            {
                LevelManager.LoadScene("GameOver");
            }
            
        }
    }


    private IEnumerator WaitForSoundBeforeSceneChange()
    {
        while (source.isPlaying)
        {
            yield return false;
        }
        LevelManager.ResetScene();
        yield return true;
    }
}
