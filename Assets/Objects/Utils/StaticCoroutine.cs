using System;
using System.Collections;
using UnityEngine;


public class StaticCoroutine : MonoBehaviour
{
    private static StaticCoroutine _instance = null;
    private static StaticCoroutine Instance
    {
        get
        {
            if(!_instance)
            {
                var findObject = FindObjectOfType<StaticCoroutine>();
                if(!findObject)
                {
                    findObject = new GameObject("Utilities").AddComponent<StaticCoroutine>();
                }
                _instance = findObject;
            }
            return _instance;
        }
    }


    private IEnumerator Perform(IEnumerator coroutine, Action onComplete = null)
    {
        onComplete = onComplete ?? delegate { };
        yield return StartCoroutine(coroutine);
        onComplete();
    }

    public static void DoCoroutine(IEnumerator coroutine, Action onComplete = null)
    {
        Instance.StartCoroutine(Instance.Perform(coroutine, onComplete));
    }
}
