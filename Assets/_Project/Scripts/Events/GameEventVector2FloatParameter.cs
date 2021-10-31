using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventVector2FloatParameter : ScriptableObject, IGameEvent<Vector2, float>
{
    public event Action<Vector2, float> gameEvent;

    public void RegisterListener(Action<Vector2, float> method)
    {
        gameEvent += method;
    }

    public void UnregisterListener(Action<Vector2, float> method)
    {
        gameEvent -= method;
    }

    public void Raise(Vector2 item1, float item2)
    {
        throw new NotImplementedException();
    }
}
