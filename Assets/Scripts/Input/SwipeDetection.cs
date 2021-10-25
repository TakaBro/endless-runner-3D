using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private GameEvent onSwipeLeft;
    [SerializeField] private GameEvent onSwipeRight;

    [SerializeField] private float minimumDistance = .2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = .9f;
    [SerializeField] private InputManager inputManager;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private float startTime;
    private float endTime;

    public void SwipeStart(Vector2 position, float time)
    {   
        startPosition = position;
        startTime = time;
    }

    public void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe(position);
    }

    private void DetectSwipe(Vector2 position)
    {
        if (Vector2.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime && (position != new Vector2(0, 0)))
        {
            //Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector2 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("Swipe Up");
        }
        else if(Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe Down");
        }else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            onSwipeLeft.Raise();
            Debug.Log("Swipe Left");
        }else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            onSwipeRight.Raise();
            Debug.Log("Swipe Right");
        }
    }
}
