using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100; // Salud inicial del zombie

    // Método para aplicar daño
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // Método para manejar la muerte del zombie
    private void Die()
    {
        // Aquí puedes agregar la lógica que desees cuando el zombie muere
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject); // Eliminar el objeto del juego (puedes cambiarlo si quieres que muera de otra manera)
    }
}

