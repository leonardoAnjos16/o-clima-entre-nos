using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private GameController gameController;
    public Interaction[] interactions;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(string powerType) {
        Interaction interaction = GetInteraction(powerType);
        if (interaction != null && InteractionIsActive(interaction)) {
            interaction.Interact(gameObject);
        }
    }

    private Interaction GetInteraction(string powerType) {
        foreach (Interaction interaction in interactions) {
            if (interaction.powerType == powerType) {
                return interaction;
            }
        }

        return null;
    }

    private bool InteractionIsActive(Interaction interaction) {
        Mission currentMission = gameController.GetMission();
        if (interaction.GetMission().name != currentMission.name) {
            return false;
        }

        return currentMission.GetInteraction().name == interaction.name;
    }
}
