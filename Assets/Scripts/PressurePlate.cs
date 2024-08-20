using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PressurePlate : MonoBehaviour
{
    private HashSet<PressurePlate> _exclusiveGroup = new();

    public LogicBehaviour logicBehaviour;

    public bool pressed
    {
        get => logicBehaviour.GetCurrentState();
        set
        {
            bool oldState = logicBehaviour.GetCurrentState();
            logicBehaviour.state = value;
            if (oldState != value && value)
            {
                foreach (var pressurePlate in _exclusiveGroup)
                {
                    pressurePlate.pressed = false;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent == null) return;
        _exclusiveGroup = transform.parent.GetComponentsInChildren<PressurePlate>().Where(pp => pp != this).ToHashSet();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player")) return;
        pressed = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
