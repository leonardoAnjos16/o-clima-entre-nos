using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;
    public float speed;

    private new SpriteRenderer renderer;
    private bool facingRight, shouldMove;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = shouldMove = true;
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldMove) return;
        animator.SetBool("walking", false);

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

        float newX = Mathf.Clamp(transform.position.x + dx, gameController.minX - 8f, gameController.maxX + 8f);
        float newY = Mathf.Clamp(transform.position.y + dy, gameController.minY - 3.5f, gameController.maxY);

        Vector3 cameraPosition = Camera.main.transform.position;
        if (newX < gameController.minX || newX > gameController.maxX) {
            cameraPosition.x -= newX - transform.position.x;
        }

        if (newY < gameController.minY) {
            cameraPosition.y -= newY - transform.position.y;
        }

        Camera.main.transform.position = cameraPosition;
        transform.position = new Vector3(newX, newY, 0f);
    }

    public void Stop() {
        shouldMove = false;
    }
}
