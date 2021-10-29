using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private GameObject _gameOverPopup;

    public void UpdateCoinsCounter(string points)
    {
        _scoreText.text = points;
    }

    public void EnableGameOverPopup()
    {
        _gameOverPopup.SetActive(true);
    }
}
