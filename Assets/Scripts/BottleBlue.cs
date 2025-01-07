using UnityEngine;

public class BottleBlue : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador toca el objeto
        if (other.CompareTag("Player")) // El jugador debe tener el tag "Player"
        {
            // Cambiar la m�sica usando el MusicManager
            MusicManager musicManager = FindObjectOfType<MusicManager>();
            if (musicManager != null)
            {
                musicManager.ChangeMusic(); // Llama a la funci�n para cambiar la m�sica
            }

            // Destruir el objeto "bottle_blue" despu�s de recogerlo
            Destroy(gameObject);
        }
    }
}
