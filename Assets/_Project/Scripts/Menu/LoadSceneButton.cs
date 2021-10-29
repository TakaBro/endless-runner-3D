using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private string sceneToLoad;

    public void LoadScene()
    {
        canvas.gameObject.SetActive(false);
        ProgressSceneLoader.instance.LoadScene(sceneToLoad);
    }
}
