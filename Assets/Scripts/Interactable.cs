using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Serializable]
    public class Interaction {
        public string type;
        public UnityEvent handler;
    }

    private Dictionary<string, UnityEvent> handlers;
    public Interaction[] interactions;

    // Start is called before the first frame update
    void Start()
    {
        handlers = new Dictionary<string, UnityEvent>();
        foreach (Interaction interaction in interactions) {
            handlers.Add(interaction.type, interaction.handler);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(string powerType) {
        if (handlers.ContainsKey(powerType)) {
            handlers[powerType].Invoke();
        }
    }
}
