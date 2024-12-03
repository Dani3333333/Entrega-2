using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Puerta : MonoBehaviour
{
    public string nombreAnimacion;
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play(nombreAnimacion);
            Destroy(gameObject);
        }
    }
}

