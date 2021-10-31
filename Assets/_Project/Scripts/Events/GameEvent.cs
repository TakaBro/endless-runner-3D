using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    public event Action gameEvent;

    public void RegisterListener(Action method)
    {
        gameEvent += method;
    }

    public void UnregisterListener(Action method)
    {
        gameEvent -= method;
    }

    public void Raise()
    {
        gameEvent.Invoke();
    }
}
