using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float _minimumDistance = .2f;
    [SerializeField] private float _maximumTime = 1f;
    [SerializeField, Range(0f, 1f)] private float _directionThreshold = .9f;

    [Header("Events to trigger:")]
    [SerializeField] private GameEvent _OnSwipeLeft;
    [SerializeField] private GameEvent _OnSwipeRight;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private float _startTime;
    private float _endTime;

    public void SwipeStart(Vector2 position, float time)
    {   
        _startPosition = position;
        _startTime = time;
    }

    public void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe(position);
    }

    private void DetectSwipe(Vector2 position)
    {
        if (Vector2.Distance(_startPosition, _endPosition) >= _minimumDistance &&
            (_endTime - _startTime) <= _maximumTime && (position != new Vector2(0, 0)))
        {
            Vector2 direction = _endPosition - _startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
        {
            Debug.Log("Swipe Up");
        }
        else if(Vector2.Dot(Vector2.down, direction) > _directionThreshold)
        {
            Debug.Log("Swipe Down");
        }else if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
        {
            _OnSwipeLeft.Raise();
            Debug.Log("Swipe Left");
        }else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
        {
            _OnSwipeRight.Raise();
            Debug.Log("Swipe Right");
        }
    }
}
