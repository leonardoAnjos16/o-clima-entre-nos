using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private int activeWindmills;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        activeWindmills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWindmills >= 2) {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }

    public void ActivateWindmill() {
        activeWindmills++;
    }
}
