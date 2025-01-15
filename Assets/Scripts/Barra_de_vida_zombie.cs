using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_de_vida_zombie : MonoBehaviour
{
    public float Salud = 100;
    public float SaludMaxima = 100;

    [Header("Muerto")]
    public GameObject Muerto; // Prefab o efecto al morir (opcional)

    public void RecibirDaño(float daño)
    {
        Salud -= daño;

        if (Salud <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        // Instancia el objeto de muerte si está configurado (animación o efecto visual)
        if (Muerto != null)
        {
            Instantiate(Muerto, transform.position, transform.rotation);
        }

        // Destruye el objeto zombie
        Destroy(gameObject);
    }
}
