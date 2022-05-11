using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject text; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(Delay());
            
        }
    }


    IEnumerator Delay()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        text.SetActive(false);



    }
}
