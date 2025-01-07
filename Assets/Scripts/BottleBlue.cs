using UnityEngine;

public class BottleBlue : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador toca el objeto
        if (other.CompareTag("Player")) // El jugador debe tener el tag "Player"
        {
            // Cambiar la música usando el MusicManager
            MusicManager musicManager = FindObjectOfType<MusicManager>();
            if (musicManager != null)
            {
                musicManager.ChangeMusic(); // Llama a la función para cambiar la música
            }

            // Destruir el objeto "bottle_blue" después de recogerlo
            Destroy(gameObject);
        }
    }
}
