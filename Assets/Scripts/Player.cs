using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public float speed, minX, maxX, minY, maxY;

    private bool facingRight;
    private new SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", false);
        if (GameController.finishedMission) return;

        float dx = 0f;
        if (Input.GetKey("right")) {
            facingRight = true;
            dx = speed * Time.deltaTime;
            animator.SetBool("walking", true);
        } else if (Input.GetKey("left")) {
            facingRight = false;
            dx = -speed * Time.deltaTime;
            animator.SetBool("walking", true);
        }

        renderer.flipX = !facingRight;

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
        transform.position = new Vector3(newX, newY, 0f);
    }
}
