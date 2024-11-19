using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerActions;
    private Animator animator;

    public Vector2 direcction;
    public float Speed = 2f;


    void ProcesMovement(InputAction.CallbackContext callbackContext)
    {

        Vector2 movement=callbackContext.ReadValue<Vector2>();
        animator.SetBool("Forward", true);
        animator.SetBool("Back", true);
        animator.SetBool("Right", true);
        animator.SetBool("Left", true);
        transform.position = new Vector3(movement.x, transform.position.y, movement.y);

    }


    void FinishMovement(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("Forward", false);
        animator.SetBool("Back", false);
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);

    }

    void Awake()
    {
        playerActions = new PlayerInputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerActions.Player.Enable();
        playerActions.Player.Move.started += ProcesMovement;
        playerActions.Player.Move.canceled += FinishMovement;
        //playerActions.Player.Move.performed += FinishMovement;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }
}
