using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // Player
    public const int PLAYER_MOVEMENT_SPEED = 5;
    public const float PLAYER_MOVEMENT_DISTANCE = 3.5f;
    public const float PLAYER_JUMP_HEIGHT = 8;
    public const string PLAYER_DATA_FILE_NAME = "player_one_data";
    public const int PLAYER_DEFAULT_COIN_VALUE = 0;

    // Platforms
    public const int PLATFORM_LENGTH = 40;
    public const float TIME_TO_RETURN_PLATFORM = 3.0f;
    public const float SCROLL_SPEED = 0.35f;

    // Coin
    public const float TIME_TO_COIN_DESTROY = .5f;

    // Leaderboard
    public const int DEFAULT_HIGHEST_SCORE = 36; 
}
