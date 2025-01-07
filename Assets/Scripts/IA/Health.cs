using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100; // Salud inicial del zombie

    // M�todo para aplicar da�o
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // M�todo para manejar la muerte del zombie
    private void Die()
    {
        // Aqu� puedes agregar la l�gica que desees cuando el zombie muere
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject); // Eliminar el objeto del juego (puedes cambiarlo si quieres que muera de otra manera)
    }
}

