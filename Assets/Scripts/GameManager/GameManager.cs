using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject gameOverPopup;
    private PlayerData playerData;
    private JsonLoader jsonLoader;

    private int points = 0;

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
        playerData = new PlayerData();
        jsonLoader = GetComponent<JsonLoader>();

        string gameDataFileName = "test";
        string filePath = Application.persistentDataPath;// + "/" + gameDataFileName;
        Debug.Log("Application.persistentDataPath : " + filePath);
        if (File.Exists(filePath))
        {
            jsonLoader.Load(filePath);
        }
    }

    public void PlayerEarnPoints(int points)
    {
        //Debug.Log("COINS BEFORE: " + playerData.points);
        this.points = this.points + points;
        scoreText.text = this.points.ToString();
        //Debug.Log("COINS AFTER: " + playerData.points);
    }

    public void PlayerDies()
    {
        PlayerController.player.SetActive(false);
        gameOverPopup.SetActive(true);
    }
}
