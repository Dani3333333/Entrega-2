using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundTrigger : MonoBehaviour
{
    private AudioSource fireAudio;

    void Start()
    {
        // Obtén el AudioSource del objeto
        fireAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            fireAudio.Play(); // Reproduce el sonido
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Comprueba si el objeto que sale del trigger es el jugador
        if (other.CompareTag("Player"))
        {
            fireAudio.Stop(); // Detén el sonido
        }
    }
}
