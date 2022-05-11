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
            outline.tag = "outline";

            SpriteRenderer outlineRenderer = outline.AddComponent<SpriteRenderer>();
            outlineRenderer.material.shader = Shader.Find("GUI/Text Shader");
            outlineRenderer.sortingOrder = renderer.sortingOrder - 1;
            outlineRenderer.sprite = renderer.sprite;
            outlineRenderer.color = Color.white;

            // outline.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
            outline.transform.position += new Vector3(.005f, .005f, 0f);
            Instantiate(outline, gameObject.transform);

            outline.transform.position -= new Vector3(.01f, .01f, 0f);
            Instantiate(outline, gameObject.transform);
            Destroy(outline);
        } else {
            foreach (Transform child in gameObject.transform) {
                AddOutline(child.gameObject);
            }
        }

        GameObject[] outlines = GameObject.FindGameObjectsWithTag("outline");

        foreach (GameObject outline in outlines) {
            outline.SetActive(false);
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

    private bool InteractionIsActive(Interaction interaction) {
        return gameController.mission.GetInteraction().name == interaction.name;
    }

    private bool ExtraInteractionIsActive(Interaction interaction) {
        return gameController.mission.HasExtra(interaction.name);
    }

    public void ChangeOutline(bool status, GameObject parent){
        //parent = this.gameObject;

         foreach (Transform child in parent.transform)
          {
            Debug.Log("entrou no change compare");

              if (child.CompareTag("outline")){
                    child.gameObject.SetActive(status);
                    Debug.Log("setou:");
                    Debug.Log(status);
              }else{
                  ChangeOutline(status, child.gameObject);
              }

          }
    }
}
