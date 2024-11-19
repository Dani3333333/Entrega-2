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

    private void OnMove(InputValue inputAction)
    {
        Vector2 input=inputAction.Get<Vector2>();
    }
    
}
