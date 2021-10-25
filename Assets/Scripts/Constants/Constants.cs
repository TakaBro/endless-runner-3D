using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // Player
    public const int PLAYER_MOVEMENT_SPEED = 5;
    public const float PLAYER_MOVEMENT_DISTANCE = 3.5f;
    public const float PLAYER_JUMP_HEIGHT = 7;

    // Platforms
    public const int PLATFORM_LENGTH = 40;
    public const float TIME_TO_RETURN_PLATFORM = 3.0f;
    public const float SCROLL_SPEED = 0.35f;

    // Coin
    public const float TIME_TO_COIN_DESTROY = .5f;
}
