using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private MovementController movementController; // Referencia al MovementController

    private void Start()
    {
        movementController = GetComponent<MovementController>(); // Obtener el MovementController
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 direction = inputValue.Get<Vector2>(); // Obtener la dirección de entrada del usuario
        movementController.OnMove(direction); // Enviar la dirección directamente al MovementController
    }
}
