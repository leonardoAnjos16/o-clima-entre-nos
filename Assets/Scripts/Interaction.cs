using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Interaction", menuName = "Scriptable Objects/Interaction")]
public class Interaction : ScriptableObject
{
    public new string name;
    public Mission mission;
    public UnityEvent<GameObject, Dictionary<string, string>> handler;

    public Mission GetMission() {
        return mission;
    }

    public void Interact(GameObject gameObject, Dictionary<string, string> data, bool isExtra = false) {
        handler.Invoke(gameObject, data);
        if (!isExtra) {
            mission.NextInteraction();
        }
    }
}
