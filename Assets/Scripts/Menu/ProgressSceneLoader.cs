using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressSceneLoader : MonoBehaviour
{
    public static ProgressSceneLoader instance;

    [SerializeField]
    private Text progressText;
    [SerializeField]
    private Slider slider;
    private Canvas canvas;

    private AsyncOperation operation;

    private void Awake()
    {
        Singleton();
        DontDestroy();

        canvas = GetComponentInChildren<Canvas>(true);
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
        canvas.gameObject.SetActive(true);

        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }

        UpdateProgressUI(operation.progress);
        operation = null;
        canvas.gameObject.SetActive(false);
    }

    private void UpdateProgressUI(float progress)
    {
        slider.value = progress;
        progressText.text = (int)(progress * 100f) + "%";
    }
}
