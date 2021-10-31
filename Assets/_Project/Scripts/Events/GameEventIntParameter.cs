using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventIntParameter : ScriptableObject, IGameEvent<int>
{
    public event Action<int> gameEvent;

    public void RegisterListener(Action<int> method)
    {
        gameEvent += method;
    }

    public void UnregisterListener(Action<int> method)
    {
        gameEvent -= method;
    }

    public void Raise(int item)
    {
        gameEvent.Invoke(item);
    }
}
