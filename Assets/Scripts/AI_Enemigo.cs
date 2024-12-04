using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemigo : MonoBehaviour
{
    public Transform Objetivo; // Referencia al jugador
    public float Velocidad = 3.5f; // Velocidad del NavMeshAgent
    public float RangoDeteccion = 10f; // Distancia para detectar al jugador
    public NavMeshAgent IA; // Componente NavMeshAgent

    public Animator Anim; // Componente Animator
    private bool jugadorDetectado = false; // Para saber si el jugador est� en rango

    void Start()
    {
        // Aseguramos que la animaci�n inicial es "Idle"
        Anim.SetBool("Caminar", false);
    }

    void Update()
    {
        // Calcular la distancia al jugador
        float distancia = Vector3.Distance(transform.position, Objetivo.position);

        if (distancia <= RangoDeteccion) // Si el jugador est� en rango
        {
            jugadorDetectado = true;
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);

            // Si el enemigo se est� moviendo, activa la animaci�n de caminar
            if (IA.velocity.magnitude > 0.1f)
            {
                Anim.SetBool("Caminar", true); // Cambia a animaci�n de caminar
            }
        }
        else
        {
            jugadorDetectado = false;
            IA.SetDestination(transform.position); // Detener al enemigo

            // Cambiar a animaci�n de estar quieto (Idle)
            Anim.SetBool("Caminar", false);
        }
    }
}
