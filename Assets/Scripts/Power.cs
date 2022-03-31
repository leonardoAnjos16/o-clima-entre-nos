using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private static float maxDistance = 1f;
    private Vector3 initialPosition;
    public string type;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag() {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp() {
        Interactable[] interactableObjects = FindObjectsOfType<Interactable>();
        foreach (Interactable interactable in interactableObjects) {
            if (Touch(interactable.gameObject)) {
                interactable.Interact(type);
            }
        }

        transform.position = initialPosition;
    }

    private bool Touch(GameObject other) {
        Vector3 difference = transform.position - other.transform.position;
        return difference.magnitude <= maxDistance;
    }
}
