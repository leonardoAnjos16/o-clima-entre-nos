using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private bool shouldRotate;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        shouldRotate = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRotate) {
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }
    }

    public void StartRotating() {
        shouldRotate = true;
    }
}
