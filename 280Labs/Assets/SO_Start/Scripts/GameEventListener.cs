using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    //The GameEvent this GameEventListener will subscribe to
    [SerializeField]
    private GameEvent gameEvent;

    //The UnityEvent response that will be invoked when the GameEvent raises this GameEventListener
    [SerializeField]
    private UnityEvent response;

    //Need to register the GameEvent to the GameEventListener when this GameObject is enabled.
    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    //unregister the GameEvent from the GAmeEventListener when this GameObject is disabled
    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    //called when a GameEvent is raised causing the GameEventListener to invoke the UnityEvent
    public void OnEventRaised()
    {
        response.Invoke();
    }
}