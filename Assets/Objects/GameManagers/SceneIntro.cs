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


    public static bool gameBegin = false;
    public bool skipIntro = false;


    private void Start()
    {
        if (skipIntro) return;

        texture.color = Color.black;
        Camera.main.orthographicSize = cameraStartSize;
        texture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        StartCoroutine(FadeToClear());
        StartCoroutine(ShowMap());

		print ("End of intro ");
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
		if (!gameBegin) yield return true;
		while (Camera.main.orthographicSize >= cameraEndSize)
        {
			var size = Camera.main.orthographicSize;
			size -= (zoomSpeed * Time.deltaTime);
			Camera.main.orthographicSize = size;
            yield return false;
        }
        gameBegin = true;
		print ("gamebegin: " + gameBegin);
        yield return true;
    }
}
