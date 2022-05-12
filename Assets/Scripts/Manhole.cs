using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shrink() {
        float target = (transform.localScale * .9f).magnitude;
        while (transform.localScale.magnitude > target) {
            transform.localScale -= new Vector3(.2f, .2f, .2f) * Time.deltaTime;
            transform.position += new Vector3(0f, .2f, 0f) * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator Throw() {
        float speed = 5f;
        Vector3 target = transform.position + new Vector3(1f, 1f, 0f);

        while ((target - transform.position).magnitude > .05f) {
            transform.position += new Vector3(speed, speed, 0f) * Time.deltaTime;
            yield return null;
        }
    }
}
