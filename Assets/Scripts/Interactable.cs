using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InteractionsDictionaryEntry {
    public string powerType;
    public Interaction interaction;
}

public class Interactable : MonoBehaviour
{
    private Dictionary<string, Interaction> _interactions;
    public InteractionsDictionaryEntry[] interactions;

    // Start is called before the first frame update
    void Start()
    {
        _interactions = new Dictionary<string, Interaction>();
        foreach (InteractionsDictionaryEntry interaction in interactions) {
            _interactions.Add(interaction.powerType, interaction.interaction);
        }
    }

    public void Interact(string powerType) {
        if (_interactions.ContainsKey(powerType)) {
            Interaction interaction = _interactions[powerType];
            if (InteractionIsActive(interaction)) {
                interaction.Interact(gameObject);
            } else if (ExtraInteractionIsActive(interaction)) {
                interaction.Interact(gameObject, true);
            }
        }
    }

    private bool MissionIsActive(Interaction interaction) {
        Mission currentMission = GameController.GetMission();
        return interaction.GetMission().name == currentMission.name;
    }

    private bool InteractionIsActive(Interaction interaction) {
        if (!MissionIsActive(interaction)) {
            return false;
        }

        return GameController.GetMission().GetInteraction().name == interaction.name;
    }

    private bool ExtraInteractionIsActive(Interaction interaction) {
        if (!MissionIsActive(interaction)) {
            return false;
        }

        return GameController.GetMission().HasExtra(interaction.name);
    }
}
