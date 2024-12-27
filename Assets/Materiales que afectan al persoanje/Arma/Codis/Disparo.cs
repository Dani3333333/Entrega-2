using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject Prefab;
    public Transform firepoint;
    public LogicaPersonaje1 logicaPersonaje; // Referencia al script LogicaPersonaje1

    // Update is called once per frame
    void Update()
    {
        // Solo disparar si el personaje tiene el arma
        if (logicaPersonaje != null && logicaPersonaje.tieneArma && Input.GetKeyDown(KeyCode.P))
        {
            ShootOne();
        }
    }

    private void ShootOne()
    {
        Instantiate(Prefab, firepoint.position, firepoint.rotation);
    }
}
