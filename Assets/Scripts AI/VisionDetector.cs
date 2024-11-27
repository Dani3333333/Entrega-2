using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetector : MonoBehaviour
{
    public float Range = 10;
    public float FieldOfView = 60;

    public Transform Player;

    public LayerMask WhatIsVisible;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsDetected());
    }

    bool IsDetected()
    {
        if (!IsInRange(Player))
            return false;
        if (!IsInFOV(Player))
            return false;
        if (!IsBlocked(Player))
            return false;
        

        return true;
    }

    private bool IsBlocked(Transform player)
    {
        Vector3 p = player.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, p, out hit, Range, WhatIsVisible))
        {
            return hit.transform != player;
        }
        return true;
    }

    private bool IsInFOV(Transform player)
    {
        Vector3 f = transform.forward;
        Vector3 p = player.position - transform.position;
        float anlgePlayer = Vector3.Angle(f,p); //TODO get real angle
        return anlgePlayer < FieldOfView / 2;
    }

    private bool IsInRange(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < Range;
    }
}
