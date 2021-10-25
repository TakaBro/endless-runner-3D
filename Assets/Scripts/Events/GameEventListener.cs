using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener<int>, IGameEventListener<Vector2, float>
{
    [Tooltip("Event to register with.")]
    public GameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent Response;
    public UnityEvent<int> ResponseOneParameter;
    public UnityEvent<Vector2, float> ResponseTwoParameter;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }

    public void OnEventRaised(int item)
    {
        ResponseOneParameter.Invoke(item);
    }

    public void OnEventRaised(Vector2 item1, float item2)
    {
        ResponseTwoParameter.Invoke(item1, item2);
    }
}
