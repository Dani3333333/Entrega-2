using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private PlayerInput playerActions;
    private Animator animator;

    public Vector2 direcction;
    public float Speed = 2f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue inputValue)
    {
        direcction = inputValue.Get<Vector2>();
        animator.SetFloat("Frontal", direcction.y);
        animator.SetFloat("Lateral", direcction.x);
    }

}

