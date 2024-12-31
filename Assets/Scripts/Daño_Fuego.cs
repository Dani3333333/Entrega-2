using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño_Fuego : MonoBehaviour
{
    public float CantidadDaño;
    public AudioSource audioSourceDaño; // Referencia al AudioSource para el daño

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Barra_vida>())
        {
            // Aplicar daño
            other.GetComponent<Barra_vida>().RecibirDaño(CantidadDaño);

            // Reproducir el sonido de daño
            if (audioSourceDaño != null && !audioSourceDaño.isPlaying)
            {
                audioSourceDaño.Play();
            }
        }
    }
}
