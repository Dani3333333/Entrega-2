using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrolling : MonoBehaviour
{
    public float Speed = 2f;
    public Transform[] Waypoints;//Això ho fem per identificar els W1,W2,W3...  
    public bool Move2D; //Per saber si s'ha de moure nomes en 2d o també en 3d a nosaltres potser nomes ens interressa en 2d
    public float MinDistance = 0.01f;

    private int _currentWaypointIndex;
    Transform CurrentWaypoint => Waypoints[_currentWaypointIndex];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CloseWaypoint())
        {
            ChangeWaypoint();
        }
        Move();
    }
    private bool CloseWaypoint()
    {
        return Vector3.Distance(transform.position, CurrentWaypoint.position) < MinDistance;
    }

    private void ChangeWaypoint()
    {
        _currentWaypointIndex++;


        _currentWaypointIndex = _currentWaypointIndex % Waypoints.Length;



    }


    private void Move()
    {
        Vector3 target = CurrentWaypoint.forward;
        if (Move2D)
        {
            target.y = transform.position.y;
        }
        transform.LookAt(CurrentWaypoint);
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
    }
}
