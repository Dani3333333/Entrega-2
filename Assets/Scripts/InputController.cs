using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private MovementController movementController; // Referencia al MovementController

    public Vector2 direction;

    private void Start()
    {
        movementController = GetComponent<MovementController>(); // Obtener el MovementController
    }

    // Método para recibir las entradas de movimiento
    void OnMove(InputValue inputValue)
    {
        direction = inputValue.Get<Vector2>(); // Obtener la dirección de entrada del usuario

        // Pasar la dirección al MovementController
        movementController.SetInputDirection(direction);
    }
}
