using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button levelOne;
    public Button levelTwo;
    public Button levelThree;
    public Button back;

    private void Start()
    {
        levelOne.onClick.AddListener(() => LevelManager.LoadScene("LevelOne"));
        levelTwo.onClick.AddListener(() => LevelManager.LoadScene("LevelTwo"));
        levelThree.onClick.AddListener(() => LevelManager.LoadScene("LevelThree"));
        back.onClick.AddListener(() => LevelManager.LoadScene("MainMenu"));
    }



}
