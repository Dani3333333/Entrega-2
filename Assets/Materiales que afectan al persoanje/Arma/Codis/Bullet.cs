using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ApplyVelocity();
    }

    private void ApplyVelocity()
    {
        _rigidbody.velocity = transform.forward * Speed;
    }
}
