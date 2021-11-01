using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    [SerializeField] private Text highestScore;
    [SerializeField] private Text playerScore;

    private int leaderboardHighestScore = Constants.DEFAULT_HIGHEST_SCORE;

    private void OnEnable()
    {
        CheckHighestScore();

        CheckPlayerScore();

        DisplayScore();
    }

    private void CheckHighestScore()
    {
        if (leaderboardHighestScore <= GameManager.instance.playerHighestScore)
        {
            leaderboardHighestScore = GameManager.instance.playerHighestScore;   
        }
    }

    private void CheckPlayerScore()
    {
        if (leaderboardHighestScore <= GameManager.instance.playerPoints)
        {
            Debug.Log("leaderboardHighestScore <= GameManager.instance.playerPoints: " + leaderboardHighestScore);
            leaderboardHighestScore = GameManager.instance.playerPoints;
        }
    }

    private void DisplayScore()
    {
        highestScore.text = leaderboardHighestScore.ToString();
        playerScore.text = GameManager.instance.playerPoints.ToString();
    }
}
