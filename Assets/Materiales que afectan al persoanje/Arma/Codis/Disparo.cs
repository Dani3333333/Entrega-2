using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject Prefab;
    public Transform firepoint;
    public LogicaPersonaje1 logicaPersonaje; // Referencia al script LogicaPersonaje1
    private AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {
        // Obtén el componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Solo disparar si el personaje tiene el arma, está apuntando (Shift) y se presiona el clic izquierdo del ratón
        if (logicaPersonaje != null && logicaPersonaje.tieneArma && Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0)) 
        {
            ShootOne();
        }
    }

    private void ShootOne()
    {
        // Instancia la bala
        Instantiate(Prefab, firepoint.position, firepoint.rotation);

        // Reproduce el sonido de disparo
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
