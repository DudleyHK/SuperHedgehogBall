using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneIntro : MonoBehaviour

{
    private GUITexture texture { get { return GetComponent<GUITexture>(); } }
    public float fadeSpeed = 1.5f;
    public float zoomSpeed = 1.5f;
    public float cameraStartSize = 15f;
    public float cameraEndSize = 3f;


    public bool gameBegin = false;
    public bool skipIntro = false;


    private void Start()
    {
        if (skipIntro) return;

        texture.color = Color.black;
        Camera.main.orthographicSize = cameraStartSize;
        texture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        StartCoroutine(FadeToClear());
        StartCoroutine(ShowMap());
    }


    private IEnumerator FadeToClear()
    {
        while (texture.color != Color.clear)
        {
            texture.color = Color.Lerp(texture.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return false;
        }

        yield return true;
    }



    private IEnumerator ShowMap()
    {
        while (Camera.main.orthographicSize >= cameraEndSize)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraEndSize, zoomSpeed * Time.deltaTime);
            yield return false;
        }
        gameBegin = true;
        yield return true;
    }
}
