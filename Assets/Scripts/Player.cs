using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Power[] powers;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        powers = FindObjectsOfType<Power>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        animator.SetBool("walking", false);

        float dx = 0f;
        if (Input.GetKey("right")) {
            dx = speed * Time.deltaTime;

            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;

            animator.SetBool("walking", true);
        } else if (Input.GetKey("left")) {
            dx = -speed * Time.deltaTime;

            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;

            animator.SetBool("walking", true);
        }

        float dy = 0f;
        if (Input.GetKey("up")) {
            dy = speed * Time.deltaTime;
            animator.SetBool("walking", true);
        } else if (Input.GetKey("down")) {
            dy = -speed * Time.deltaTime;
            animator.SetBool("walking", true);
        }

        Vector3 displacement = new Vector3(dx, dy, 0);
        transform.position += displacement;

        foreach (Power power in powers) {
            power.transform.position += displacement;
            power.initialPosition += displacement;
        }
    }
}
