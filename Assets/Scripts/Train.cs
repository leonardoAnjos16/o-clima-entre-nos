using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private int activeWindmills;
    private Animator animator;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        activeWindmills = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWindmills >= 2) {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }

    public void ActivateWindmill() {
        if (++activeWindmills >= 2) {
            animator.SetBool("move", true);
        }
    }
}
