using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressSceneLoader : MonoBehaviour
{
    public static ProgressSceneLoader instance;

    [SerializeField]
    private Text _progressText;
    [SerializeField]
    private Slider _slider;
    private Canvas _canvas;

    private AsyncOperation _operation;

    private void Awake()
    {
        Singleton();
        DontDestroy();

        _canvas = GetComponentInChildren<Canvas>(true);
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void DontDestroy()
    {
        GameObject[] sceneLoaders = GameObject.FindGameObjectsWithTag("SceneLoader");
        if (sceneLoaders.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        UpdateProgressUI(0);
        _canvas.gameObject.SetActive(true);

        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        _operation = SceneManager.LoadSceneAsync(sceneName);

        while (!_operation.isDone)
        {
            UpdateProgressUI(_operation.progress);
            yield return null;
        }

        UpdateProgressUI(_operation.progress);
        _operation = null;
        _canvas.gameObject.SetActive(false);
    }

    private void UpdateProgressUI(float progress)
    {
        _slider.value = progress;
        _progressText.text = (int)(progress * 100f) + "%";
    }
}
