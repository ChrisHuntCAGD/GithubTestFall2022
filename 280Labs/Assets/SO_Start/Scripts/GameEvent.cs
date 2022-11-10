using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
public class GameEvent : ScriptableObject
{
    //A lit of GameEventListeners that will subscribe to your Game Event.
    private List<GameEventListener> listeners = new List<GameEventListener>();
    
    //A function to invoke all of the subscribers of a GameEvent
    public void Raise()
    {
        //The last game event listener to be subscribed to will be the first to get invoked. LIFO
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            //Invoke each GameEventListener's Unity Event
            listeners[i].OnEventRaised();
        }
    }

    //A function to allow GameEventListeners to subscribe to this GameEvent
    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    //A function to allow GameEventListeners to unsubscribe to this GameEvent
    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
