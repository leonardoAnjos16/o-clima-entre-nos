using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Power[] powers;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        powers = FindObjectsOfType<Power>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0f;
        if (Input.GetKey("right")) {
            dx = speed * Time.deltaTime;
        } else if (Input.GetKey("left")) {
            dx = -speed * Time.deltaTime;
        }

        float dy = 0f;
        if (Input.GetKey("up")) {
            dy = speed * Time.deltaTime;
        } else if (Input.GetKey("down")) {
            dy = -speed * Time.deltaTime;
        }

        Vector3 displacement = new Vector3(dx, dy, 0);
        transform.position += displacement;

        foreach (Power power in powers) {
            power.transform.position += displacement;
            power.initialPosition += displacement;
        }
    }
}
