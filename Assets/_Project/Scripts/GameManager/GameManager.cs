using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public int playerPoints = Constants.PLAYER_DEFAULT_COIN_VALUE;
    public int playerHighestScore;

    [SerializeField] private UIHandler uiController;

    [Header("Events to register:")] // As listener
    [SerializeField] private GameEventIntParameter _OnCoinPicked;
    [SerializeField] private GameEvent _OnPlayerDies;

    private PlayerData _playerData;
    private JsonLoader _jsonLoader;

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
        InitializePlayerData();

        LoadPlayerData();

        RegisterAsListener();
    }

    private void InitializePlayerData()
    {
        _playerData = new PlayerData();
        _jsonLoader = GetComponent<JsonLoader>();
    }

    private void LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "/" + Constants.PLAYER_DATA_FILE_NAME;

        if (File.Exists(filePath))
        {
            _playerData =  _jsonLoader.Load(filePath);
            playerHighestScore = _playerData.highestScore;
            Debug.Log("_playerData: " + _playerData);
            Debug.Log("playerHighestScore: " + playerHighestScore);
        }
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

    private void PlayerEarnPoints(int points)
    {
        playerPoints = playerPoints + points;
        uiController.UpdateCoinsCounter(playerPoints.ToString());
    }

    private void PlayerDies()
    {
        LoadPlayerData();
        player.gameObject.SetActive(false);
        uiController.EnableGameOverPopup();
        SavePlayerData();
    }

    private void SavePlayerData()
    {
        if (playerPoints > playerHighestScore)
        {
            playerHighestScore = playerPoints;
        }

        _playerData.name = "Taka";
        _playerData.highestScore = playerHighestScore;
        Debug.Log("Application.persistentDataPath : " + _playerData);

        File.WriteAllText(Application.persistentDataPath + "/" + Constants.PLAYER_DATA_FILE_NAME, JsonConvert.SerializeObject(_playerData));
    }
}
