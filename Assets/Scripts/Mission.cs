using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Objects/Mission")]
public class Mission: ScriptableObject
{
    public new string name;
    public string description;

    private int interactionIndex;
    public Interaction[] needed, extra;

    public void Init() {
        interactionIndex = 0;
    }

    public Interaction GetInteraction() {
        return needed[interactionIndex];
    }

    public void NextInteraction() {
        GameController gameController = FindObjectOfType<GameController>();
        if (++interactionIndex >= needed.Length) {
            gameController.NextMission();
        }
    }

    public bool HasExtra(string name) {
        foreach (Interaction interaction in extra) {
            if (interaction.name == name) {
                return true;
            }
        }

        return false;
    }
}
