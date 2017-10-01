using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath : MonoBehaviour
{
    public GameObject killBox;
    public AudioClip die;


    private PlayerData playerData;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }




    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
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
            playerData.modifyLives(-1);
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
