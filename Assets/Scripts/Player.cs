using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Power[] powers;
    public float speed, minX, maxX, minY, maxY;

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

        float newX = Mathf.Clamp(transform.position.x + dx, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y + dy, minY, maxY);

        Vector3 newPosition = new Vector3(newX, newY, 0f);
        Vector3 displacement = newPosition - transform.position;
        transform.position = newPosition;

        foreach (Power power in powers) {
            power.transform.position += displacement;
            power.initialPosition += displacement;
        }
    }
}
