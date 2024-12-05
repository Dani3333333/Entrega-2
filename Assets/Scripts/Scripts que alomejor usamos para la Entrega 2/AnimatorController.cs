using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private MovementController movementController; // Referencia al MovementController

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<MovementController>(); // Obtener el MovementController
    }

    // Update is called once per frame
    void Update()
    {
        // Usamos CurrentSpeed para actualizar la animación según la velocidad del personaje
        animator.SetFloat("Frontal", movementController.CurrentSpeed);
    }
}
