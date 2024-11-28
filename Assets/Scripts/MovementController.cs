using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float rotationSpeed = 700f; // Velocidad de rotación para que el personaje se gire hacia la dirección del movimiento

    private Vector2 direction; // Dirección de movimiento
    private Rigidbody rb; // Componente Rigidbody para controlar el movimiento físico

    Vector3 movement;

    public float CurrentSpeed => movement.magnitude / Time.deltaTime / moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody del personaje
    }

    public void OnMove(Vector2 inputDirection)
    {
        direction = inputDirection; // Actualizar la dirección del movimiento

        if (direction.magnitude > 0) // Si hay alguna dirección de movimiento
        {
            // Calcula el movimiento en el espacio (Vector3)
            movement = new Vector3(direction.x, 0f, direction.y) * moveSpeed * Time.deltaTime;

            // Mover al personaje en el espacio 3D
            rb.MovePosition(transform.position + movement);

            // Rotar el personaje en la dirección del movimiento
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            movement = Vector3.zero;
        }
    }
}
