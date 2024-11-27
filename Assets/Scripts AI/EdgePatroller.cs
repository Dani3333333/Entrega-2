using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EdgePatroller : MonoBehaviour
{
    public Transform DetectionPoint;

    public float Speed = 2f;

    public LayerMask WhatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
            Turn();

        Move();
       
    }

    private void Move()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);

    }

    private void Turn()
    {
       transform.Rotate(new Vector3(0, Random.Range(90, 270), 0)); //Només volem que es mogui amb l'eix y, per tant el x i el z els deixem a 0, i el y hem de posar el random range, amb el minim i el maixm de graus que pot girar
    }

    private bool EdgeDetected()
    {
        return !Physics.Raycast(DetectionPoint.position, Vector3.down, 1.15f, WhatIsGround);
    }
}
