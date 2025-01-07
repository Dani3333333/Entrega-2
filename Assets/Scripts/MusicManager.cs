using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Música inicial
    public AudioClip bottleBlueMusic; // Música que se reproducirá tras recoger "bottle_blue"

    private AudioSource audioSource;

    void Start()
    {
        // Configurar el AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ChangeMusic()
    {
        // Cambia la música si hay un nuevo clip configurado
        if (bottleBlueMusic != null)
        {
            audioSource.Stop(); // Detén la música actual
            audioSource.clip = bottleBlueMusic; // Asigna el nuevo clip
            audioSource.Play(); // Reproduce el nuevo clip
        }
    }
}
