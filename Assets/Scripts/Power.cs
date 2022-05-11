using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private static float maxDistance = 1f;

    private GameController gameController;
    private bool dragging;
    private float dx, dy;
    public string type;
    private Interactable[] interactableObjects;

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        gameController = FindObjectOfType<GameController>();
        dx = transform.position.x - Camera.main.transform.position.x;
        dy = transform.position.y - Camera.main.transform.position.y;
        interactableObjects = FindObjectsOfType<Interactable>();
    }

    // Update is called once per frame
    void Update() {
        if (!dragging) {
            UpdatePosition();
        }
    }

    private void UpdatePosition() {
        float x = Camera.main.transform.position.x + dx;
        float y = Camera.main.transform.position.y + dy;
        transform.position = new Vector3(x, y, 0f);
    }

    private void OnMouseEnter() {
        Cursor.SetCursor(gameController.mouseHand, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDrag() {
        dragging = true;
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (Interactable interactable in interactableObjects) {
            if (Touch(interactable.gameObject)) {
                interactable.ChangeOutline(true, interactable.gameObject);
            }else{
                interactable.ChangeOutline(false, interactable.gameObject);
            }
        }
    }

    private void OnMouseUp() {
        Cursor.SetCursor(gameController.mousePointer, Vector2.zero, CursorMode.Auto);

        foreach (Interactable interactable in interactableObjects) {
            if (Touch(interactable.gameObject)) {
                interactable.Interact(type);
            }
        }

        UpdatePosition();
        dragging = false;
    }

    private void OnMouseExit() {
        Cursor.SetCursor(gameController.mousePointer, Vector2.zero, CursorMode.Auto);
    }

    private bool Touch(GameObject other) {
        Vector3 difference = transform.position - other.transform.position;
        return difference.magnitude <= maxDistance;
    }
}
