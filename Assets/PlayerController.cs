//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;


//public class PlayerController : MonoBehaviour
//{
//    private PlayerInput playerActions;
//    private Animator animator;

//    public Vector2 direcction;
//    public float Speed = 2f;



//}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator; // Referencia al Animator
    public float speed = 2f;   // Velocidad de movimiento

    void Start()
    {
        // Obtener el componente Animator al inicio
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Capturar entradas del teclado directamente
        float lateral = 0f;
        float frontal = 0f;

        if (Keyboard.current.wKey.isPressed) frontal += 1f;
        if (Keyboard.current.sKey.isPressed) frontal -= 1f;
        if (Keyboard.current.dKey.isPressed) lateral += 1f;
        if (Keyboard.current.aKey.isPressed) lateral -= 1f;

        // Normalizar el movimiento para evitar velocidades inconsistentes en diagonales
        Vector3 moveDirection = new Vector3(lateral, 0, frontal).normalized;

        // Actualizar el Blend Tree en el Animator
        animator.SetFloat("Frontal", moveDirection.z);
        animator.SetFloat("Lateral", moveDirection.x);

        // Mover al personaje en la dirección deseada
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}

