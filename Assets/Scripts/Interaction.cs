using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Interaction", menuName = "Scriptable Objects/Interaction")]
public class Interaction : ScriptableObject
{
    public Mission mission;
    public new string name;
    public string powerType;
    public UnityEvent<GameObject> handler;

    public Mission GetMission() {
        return mission;
    }

    public void Interact(GameObject gameObject) {
        handler.Invoke(gameObject);
        mission.NextInteraction();
    }
}
