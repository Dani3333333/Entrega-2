using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño_Fuego : MonoBehaviour
{
    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && other.GetComponent<Barra_vida>())
        {
            other.GetComponent<Barra_vida>().RecibirDaño(CantidadDaño);
        } 
    }
}
