using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Fall() {
        float initialX = transform.position.x;
        float initialY = transform.position.y;

        while (transform.position.y > initialY - 3f) {
            transform.position -= new Vector3(3f * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= initialX - 2.4f) {
                transform.position -= new Vector3(0f, 3f * Time.deltaTime, 0f);
            }

            yield return null;
        }
    }
}
