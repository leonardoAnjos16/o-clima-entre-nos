using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public void Grow(GameObject gameObject) {
        gameObject.transform.localScale = new Vector3(2f, 2f, 0f);
    }

    public void Shrink(GameObject gameObject) {
        gameObject.transform.localScale = new Vector3(1f, 1f, 0f);
    }

    public void DestroyObject(GameObject gameObject) {
        Destroy(gameObject);
    }
}
