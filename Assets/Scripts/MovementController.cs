using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float rotationSpeed = 700f; // Velocidad de rotación para que el personaje se gire hacia la dirección del movimiento
    
    public float jumpForce = 5f; // Fuerza del salto
    public LayerMask groundLayer; // Capa que identifica el suelo
    public float groundCheckDistance = 0.1f; // Distancia para verificar si está en el suel0

    private Vector2 direction; // Dirección de movimiento
    private Rigidbody rb; // Componente Rigidbody para controlar el movimiento físico
    private bool isGrounded; // Indica si el personaje está tocando el suelo

    Vector3 movement;

    public float CurrentSpeed => movement.magnitude / Time.deltaTime / moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody del personaje
    }

    public void SetDirection(Vector2 inputDirection)
    {
        direction = inputDirection; // Actualizar la dirección del movimiento desde el InputController
    }

    public void Jump()
    {
        if (isGrounded) // Solo puede saltar si está en el suelo
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        MoveCharacter();
        CheckGrounded(); // Verificar si el personaje está en el suelo
    }

    private void MoveCharacter()
    {
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

    private void CheckGrounded()
    {
        // Realiza un Raycast hacia abajo para verificar si el personaje está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
