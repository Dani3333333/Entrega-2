using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject Prefab;
    public Transform firepoint;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
            ShootOne();


    }

    private void ShootOne()
    {

        Instantiate(Prefab, firepoint.position, firepoint.rotation); //Hem creat el rot al private void SpawnInPlane         
    }

}
