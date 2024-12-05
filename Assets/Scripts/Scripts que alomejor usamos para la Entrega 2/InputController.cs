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

    // M�todo para recibir las entradas de movimiento
    void OnMove(InputValue inputValue)
    {
        direction = inputValue.Get<Vector2>(); // Obtener la direcci�n de entrada del usuario

        // Pasar la direcci�n al MovementController
        movementController.SetInputDirection(direction);
    }
}
