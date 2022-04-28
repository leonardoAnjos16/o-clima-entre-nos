using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactions", menuName = "Scriptable Objects/Interactions")]
public class Interactions: ScriptableObject
{
    public void Grow(GameObject gameObject, Dictionary<string, string> data) {
        gameObject.transform.localScale = new Vector3(2f, 2f, 0f);
    }

    public void Shrink(GameObject gameObject, Dictionary<string, string> data) {
        gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
    }

    public void DestroyObject(GameObject gameObject, Dictionary<string, string> data) {
        Destroy(gameObject);
    }

    public void Wind(GameObject gameObject, Dictionary<string, string> data) {
        if (data["object"] == "chest") {
            Chest chest = gameObject.GetComponent<Chest>();
            chest.StartCoroutine(chest.Fall());
        } else {
            if (data["direction"] == "right-up") {
                gameObject.transform.position += new Vector3(1f, 1f, 0f);
            } else if (data["direction"] == "left-up") {
                gameObject.transform.position += new Vector3(-1f, 1f, 0f);
            } else if (data["direction"] == "left-down") {
                gameObject.transform.position += new Vector3(-1f, -1f, 0f);
            }
        }
     }
}
