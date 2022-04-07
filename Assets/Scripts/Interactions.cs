using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactions", menuName = "Scriptable Objects/Interactions")]
public class Interactions: ScriptableObject
{
    public void Grow(GameObject gameObject) {
        gameObject.transform.localScale = new Vector3(2f, 2f, 0f);
    }

    public void Shrink(GameObject gameObject) {
        gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
    }

    public void DestroyObject(GameObject gameObject) {
        Destroy(gameObject);
    }
}
