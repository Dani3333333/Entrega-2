using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemigo2 : MonoBehaviour
{
    public Transform Objetivo; // Referencia al jugador
    public float Velocidad = 3.5f; // Velocidad del NavMeshAgent
    public float RangoDeteccion = 10f; // Distancia para detectar al jugador
    public float RangoAtaque = 1.5f; // Distancia para atacar al jugador
    public NavMeshAgent IA; // Componente NavMeshAgent

    private Animator Anim; // Componente Animator
    private bool jugadorDetectado = false; // Para saber si el jugador est� en rango
    private bool Golpeando = false; // Para saber si el enemigo est� golpeando

    public float Da�o = 10f; // Da�o que el enemigo inflige al jugador
    public GameObject OndaExpansivaPrefab; // Prefab del cilindro para la onda expansiva
    public float DuracionOnda = 1f; // Duraci�n de la onda expansiva

    private float tiempoUltimoGolpe = 0f; // Controlar el tiempo entre golpes
    public float intervaloGolpes = 1f; // Intervalo entre golpes

    void Start()
    {
        // Obtenemos el componente Animator desde el GameObject del enemigo
        Anim = GetComponent<Animator>();

        // Aseguramos que la animaci�n inicial es "Idle"
        Anim.SetBool("Caminando", false);
        Anim.SetBool("Golpeando", false);
    }

    void Update()
    {
        // Calcular la distancia al jugador
        float distancia = Vector3.Distance(transform.position, Objetivo.position);

        if (distancia <= RangoDeteccion && distancia > RangoAtaque) // Si el jugador est� en rango pero fuera de ataque
        {
            jugadorDetectado = true;
            Golpeando = false; // Deja de golpear si no est� lo suficientemente cerca
            Anim.SetBool("Golpeando", false); // Dejar de golpear
            IA.isStopped = false; // Permitir que el enemigo se mueva
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);

            // Si el enemigo est� cerca del destino, activa/desactiva la animaci�n de caminar
            if (IA.remainingDistance > IA.stoppingDistance)
            {
                Anim.SetBool("Caminando", true); // Activa caminar
            }
            else
            {
                Anim.SetBool("Caminando", false); // Deja de caminar
            }
        }
        else if (distancia <= RangoAtaque) // Si el jugador est� en rango de ataque
        {
            jugadorDetectado = true;
            Golpeando = true; // Activa el golpe
            Anim.SetBool("Golpeando", true); // Cambia a animaci�n de golpear
            Anim.SetBool("Caminando", false); // Deja de caminar
            IA.isStopped = true; // Detener al enemigo para golpear

            // Comprobar si puede golpear nuevamente
            if (Time.time >= tiempoUltimoGolpe + intervaloGolpes)
            {
                GenerarOndaExpansiva(); // Generar la onda expansiva
                tiempoUltimoGolpe = Time.time; // Actualizar el tiempo del �ltimo golpe
            }
        }
        else // Si el jugador est� fuera del rango de detecci�n
        {
            jugadorDetectado = false;
            Golpeando = false;
            Anim.SetBool("Caminando", false); // Asegura que no est� caminando
            Anim.SetBool("Golpeando", false); // Asegura que no est� golpeando
            IA.SetDestination(transform.position); // Detener al enemigo
            IA.isStopped = true;
        }
    }

    void GenerarOndaExpansiva()
    {
        if (OndaExpansivaPrefab != null)
        {
            // Instanciar el prefab de la onda expansiva en la posici�n del enemigo
            GameObject onda = Instantiate(OndaExpansivaPrefab, transform.position, Quaternion.identity);
            onda.transform.position += new Vector3(0, 1f, 0); // Elevar la onda 1 unidad en el eje Y

            // Activar la onda expansiva (si est� desactivada por defecto)
            onda.SetActive(true);

            // Destruir la onda despu�s de un tiempo
            Destroy(onda, DuracionOnda);
        }
    }
}
