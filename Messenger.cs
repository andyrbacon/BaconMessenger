using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public abstract class Messenger : MonoBehaviour {

    private Dictionary <string, UnityAction<object>> myEvents = new Dictionary<string, UnityAction<object>>();

    public void AddEvent(string eventName, UnityAction<object> listener){
        myEvents.Add (eventName, listener);
    }

    public void Call(string eventName, object param = null){
        EventManager.TriggerEvent (eventName, param);
    }

    void OnEnable ()
    {
        foreach (KeyValuePair<string, UnityAction<object>> e in myEvents) {
            EventManager.StartListening (e.Key, e.Value);
        }
    }

    void OnDisable ()
    {
        foreach (KeyValuePair<string, UnityAction<object>> e in myEvents) {
            EventManager.StopListening (e.Key, e.Value);
        }
    }
}
