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

    public void Wind(GameObject gameObject){
        Debug.Log("entrou em Wind");
        if (gameObject.tag == "table1") {
            gameObject.transform.position = new Vector3(0f, 1.2f, 0f);

        }else if(gameObject.tag == "table2"){
            gameObject.transform.position = new Vector3(0f, -3f, 0f);

        }
     }
}
