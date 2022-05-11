using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject pannel; 

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
        yield return new WaitForSeconds(1);
        pannel.SetActive(true);
        Destroy(this);


    }
}
