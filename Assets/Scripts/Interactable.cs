using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DataDictionaryEntry {
    public string key, value;
}

[Serializable]
public class InteractionsDictionaryEntry {
    public string powerType;
    public int maxAllowedUses;
    public Interaction interaction;
}

public class Interactable : MonoBehaviour
{
    private Dictionary<string, string> _data;
    public DataDictionaryEntry[] data;

    private Dictionary<string, int> usesCount;
    private Dictionary<string, Tuple<Interaction, int>> _interactions;
    public InteractionsDictionaryEntry[] interactions;

    // Start is called before the first frame update
    void Start()
    {
        _data = new Dictionary<string, string>();
        foreach (DataDictionaryEntry pieceOfData in data) {
            _data.Add(pieceOfData.key, pieceOfData.value);
        }

        usesCount = new Dictionary<string, int>();
        _interactions = new Dictionary<string, Tuple<Interaction, int>>();

        foreach (InteractionsDictionaryEntry interaction in interactions) {
            usesCount.Add(interaction.powerType, 0);
            _interactions.Add(interaction.powerType, new Tuple<Interaction, int>(interaction.interaction, interaction.maxAllowedUses));
        }
    }

    public void Interact(string powerType) {
        if (_interactions.ContainsKey(powerType)) {
            if (usesCount[powerType] < _interactions[powerType].Item2) {
                Interaction interaction = _interactions[powerType].Item1;
                if (InteractionIsActive(interaction)) {
                    usesCount[powerType]++;
                    interaction.Interact(gameObject, _data);
                } else if (ExtraInteractionIsActive(interaction)) {
                    usesCount[powerType]++;
                    interaction.Interact(gameObject, _data, true);
                }
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
