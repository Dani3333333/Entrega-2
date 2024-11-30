using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float rotationSpeed = 700f; // Velocidad de rotación
    private Rigidbody rb;

    private Vector3 movementDirection = Vector3.zero; // Dirección de movimiento
    private bool isMoving = false; // Para controlar si el personaje está en movimiento

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody para mover al personaje
    }

    // Este método es llamado desde el InputController para actualizar la dirección de movimiento
    public void SetInputDirection(Vector2 inputDirection)
    {
        if (inputDirection.magnitude > 0.1f)  // Solo actualizar si hay una entrada significativa
        {
            movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y).normalized;
            isMoving = true; // El personaje está en movimiento
        }
        else
        {
            movementDirection = Vector3.zero; // Si no hay entrada, detener el movimiento
            isMoving = false; // El personaje se detiene
        }
    }

    private void FixedUpdate()
    {
        if (isMoving && movementDirection != Vector3.zero)
        {
            // Mover al personaje en la dirección dada
            Vector3 newPosition = rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            // Rotar hacia la dirección en la que se mueve el personaje
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            // Detener el movimiento si no hay dirección
            rb.velocity = Vector3.zero; // Detener el Rigidbody
        }
    }

    // Propiedad para obtener la velocidad actual del personaje
    public float CurrentSpeed
    {
        get
        {
            return rb.velocity.magnitude; // Magnitud de la velocidad, que es la "actual" velocidad de movimiento
        }
    }
}
