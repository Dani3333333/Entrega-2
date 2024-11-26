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

    void OnMove(InputValue inputValue)
    {
        direction = inputValue.Get<Vector2>(); // Obtener la dirección de entrada del usuario
        

        movementController.SetDirection(direction); // Enviar la dirección al MovementController
    }
    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed) // Detectar si el botón de salto fue presionado
        {
            movementController.Jump(); // Llamar al método Jump en MovementController
        }
    }


}