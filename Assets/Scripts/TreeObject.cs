using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObject : MonoBehaviour
{
    public float angle;

    public IEnumerator Shake() {
        float speed = 50f;
        while (transform.eulerAngles.z < angle) {
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
            yield return null;
        }

        transform.eulerAngles = new Vector3(0f, 0f, angle);
        while (transform.eulerAngles.z < angle + 1f || transform.eulerAngles.z >= 360f - angle) {
            transform.Rotate(new Vector3(0f, 0f, -speed * Time.deltaTime));
            yield return null;
        }

        transform.eulerAngles = new Vector3(0f, 0f, 360f - angle);
        while (transform.eulerAngles.z > angle - 1f) {
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
            yield return null;
        }

        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
