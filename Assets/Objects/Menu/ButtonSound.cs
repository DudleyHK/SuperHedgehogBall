using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    public AudioClip selectSound;
    public AudioClip moveSound;
    private EventSystem eventSystem;
    private GameObject prevSelectedObject;
   // private GameObject currentSelectedObject;
    private Button button { get { return this.GetComponent<Button>(); } }
    private AudioSource source { get { return this.GetComponent<AudioSource>(); } }

    private void Start()
    {
        eventSystem = EventSystem.current.GetComponent<EventSystem>();
        gameObject.AddComponent<AudioSource>();
        prevSelectedObject = eventSystem.firstSelectedGameObject;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound(selectSound));
    }

    private void PlaySound(AudioClip sound)
    {
        source.clip = sound;
        source.PlayOneShot(sound);
    }


    private void Update()
    {
        var currentSelectedObject = eventSystem.currentSelectedGameObject;
        if (currentSelectedObject != prevSelectedObject)
        {
            PlaySound(moveSound);
        }
        prevSelectedObject = currentSelectedObject;
    }
}
