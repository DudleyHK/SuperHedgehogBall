using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaCollectable : MonoBehaviour
{
    private AudioSource source { get { return this.GetComponent<AudioSource>(); } }

    public void DestroyBanana()
    {
        CollectedAudio();
        StartCoroutine(DestroyOnceEffectsHaveFinished());
    }

    private void CollectedAudio()
    {
        if (!source.isPlaying)
            source.Play();
    }



    private IEnumerator DestroyOnceEffectsHaveFinished()
    {
        while (source.isPlaying)
        {
            yield return false;
        }
        Destroy(this.gameObject);
        yield return true;
    }
}
