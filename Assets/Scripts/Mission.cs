using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Objects/Mission")]
public class Mission: ScriptableObject
{
    private GameController gameController;
    private int interactionIndex;
    public new string name;
    public string description;
    public Interaction[] needed, extra;

    public void Create(GameController gameController) {
        this.interactionIndex = 0;
        this.gameController = gameController;
    }

    public Interaction GetInteraction() {
        return needed[interactionIndex];
    }

    public void NextInteraction() {
        if (++interactionIndex >= needed.Length) {
            gameController.NextMission();
        }
    }
}
