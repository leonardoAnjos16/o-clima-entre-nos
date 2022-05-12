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
    private GameController gameController;

    private Dictionary<string, string> _data;
    public DataDictionaryEntry[] data;

    private Dictionary<string, int> usesCount;
    private Dictionary<string, Tuple<Interaction, int>> _interactions;
    public InteractionsDictionaryEntry[] interactions;

    public float outlineWidth = 0.005f;
    private List<GameObject> outlines = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();

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

        AddOutline(gameObject);
    }

    private void AddOutline(GameObject gameObject) {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        if (renderer != null) {
            GameObject outline = new GameObject();
            outline.name = "outline";

            SpriteRenderer outlineRenderer = outline.AddComponent<SpriteRenderer>();
            outlineRenderer.material.shader = Shader.Find("GUI/Text Shader");
            outlineRenderer.sortingOrder = renderer.sortingOrder - 1;
            outlineRenderer.sprite = renderer.sprite;
            outlineRenderer.color = Color.white;

            outline.transform.position += new Vector3(outlineWidth, outlineWidth, 0f);
            GameObject addedOutline = Instantiate(outline, gameObject.transform);
            addedOutline.SetActive(false);
            outlines.Add(addedOutline);

            outline.transform.position -= new Vector3(2 * outlineWidth, 2 * outlineWidth, 0f);
            addedOutline = Instantiate(outline, gameObject.transform);
            addedOutline.SetActive(false);
            outlines.Add(addedOutline);

            Destroy(outline);
        } else {
            foreach (Transform child in gameObject.transform) {
                AddOutline(child.gameObject);
            }
        }
    }

    public bool ShouldInteract(string powerType) {
        if (!_interactions.ContainsKey(powerType)) return false;
        if (usesCount[powerType] >= _interactions[powerType].Item2) return false;

        Interaction interaction = _interactions[powerType].Item1;
        return InteractionIsActive(interaction) || ExtraInteractionIsActive(interaction);
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

    private bool InteractionIsActive(Interaction interaction) {
        return gameController.mission.GetInteraction().name == interaction.name;
    }

    private bool ExtraInteractionIsActive(Interaction interaction) {
        return gameController.mission.HasExtra(interaction.name);
    }

    public void ChangeOutline(bool status){
        foreach (GameObject outline in outlines) {
            outline.SetActive(status);
        }
    }
}
