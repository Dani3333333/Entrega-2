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
        direction = inputValue.Get<Vector2>(); // Obtener la direcci�n de entrada del usuario
        

        movementController.SetDirection(direction); // Enviar la direcci�n al MovementController
    }
    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed) // Detectar si el bot�n de salto fue presionado
        {
            movementController.Jump(); // Llamar al m�todo Jump en MovementController
        }
    }


}