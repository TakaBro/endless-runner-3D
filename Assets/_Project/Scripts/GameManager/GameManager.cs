using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;

    [SerializeField] private UIController uiController;

    private PlayerData _playerData;
    private JsonLoader _jsonLoader;

    private int _points = 0;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _playerData = new PlayerData();
        _jsonLoader = GetComponent<JsonLoader>();

        string gameDataFileName = "test";
        string filePath = Application.persistentDataPath;// + "/" + gameDataFileName;
        Debug.Log("Application.persistentDataPath : " + filePath);
        if (File.Exists(filePath))
        {
            _jsonLoader.Load(filePath);
        }
    }

    public void PlayerEarnPoints(int points)
    {
        _points = _points + points;
        uiController.UpdateCoinsCounter(_points.ToString());
    }

    public void PlayerDies()
    {
        player.gameObject.SetActive(false);
        uiController.EnableGameOverPopup();
    }
}
