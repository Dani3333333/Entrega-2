using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource audioSource; // El componente AudioSource
    public AudioClip[] footstepClips; // Lista de sonidos de pasos
    public float stepInterval = 0.5f; // Tiempo entre pasos

    private CharacterController characterController; // Controlador del personaje
    private float stepTimer = 0f; // Temporizador para los pasos

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Verifica si el personaje se está moviendo
        if (characterController != null && characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime; // Reduce el temporizador
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval; // Reinicia el temporizador
            }
        }
        else
        {
            stepTimer = 0f; // Reinicia el temporizador si no se mueve
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            // Selecciona un sonido aleatorio de la lista
            int index = Random.Range(0, footstepClips.Length);
            audioSource.PlayOneShot(footstepClips[index]);
        }
    }
}
