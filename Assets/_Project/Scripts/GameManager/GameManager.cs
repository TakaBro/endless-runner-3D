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

    [Header("Events to register:")] // As listener
    [SerializeField] private GameEventIntParameter _OnCoinPicked;
    [SerializeField] private GameEvent _OnPlayerDies;

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

    private void OnEnable()
    {
        RegisterAsListener();
    }

    private void RegisterAsListener()
    {
        _OnCoinPicked.RegisterListener(PlayerEarnPoints);
        _OnPlayerDies.RegisterListener(PlayerDies);
    }

    private void OnDisable()
    {
        UnregisterAsListener();
    }

    private void UnregisterAsListener()
    {
        _OnCoinPicked.UnregisterListener(PlayerEarnPoints);
        _OnPlayerDies.UnregisterListener(PlayerDies);
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

    private void PlayerEarnPoints(int points)
    {
        _points = _points + points;
        uiController.UpdateCoinsCounter(_points.ToString());
    }

    private void PlayerDies()
    {
        player.gameObject.SetActive(false);
        uiController.EnableGameOverPopup();
    }
}
