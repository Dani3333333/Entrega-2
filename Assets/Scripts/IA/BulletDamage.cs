using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10; // Cantidad de daño que hace la bala

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisiona tiene el tag "zombie"
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Obtener el componente de salud del zombie
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                // Aplicar daño al zombie
                health.TakeDamage(damage);
            }

            // Destruir la bala después de impactar
            Destroy(gameObject);
        }
    }
}

