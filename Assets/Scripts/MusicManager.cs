using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // M�sica inicial
    public AudioClip bottleBlueMusic; // M�sica que se reproducir� tras recoger "bottle_blue"

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
        // Cambia la m�sica si hay un nuevo clip configurado
        if (bottleBlueMusic != null)
        {
            audioSource.Stop(); // Det�n la m�sica actual
            audioSource.clip = bottleBlueMusic; // Asigna el nuevo clip
            audioSource.Play(); // Reproduce el nuevo clip
        }
    }
}
