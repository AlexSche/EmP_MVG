using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerGravityObject : MonoBehaviour
{
    private Rigidbody _rb;

    public float acceleration = 0.2f;

    private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindWithTag("Player").transform;
        _rb.useGravity = false;
        _rb.maxLinearVelocity = 1.5f;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(-_player.transform.up * acceleration);
    }
}
