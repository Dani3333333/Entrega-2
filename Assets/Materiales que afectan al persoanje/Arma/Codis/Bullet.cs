using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Speed;
    public float CantidadDaño; // Daño que inflige la bala

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ApplyVelocity();
    }

    private void ApplyVelocity()
    {
        _rigidbody.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto tiene el tag "Zombie"
        if (other.CompareTag("Zombie") && other.GetComponent<Barra_vida>())
        {
            // Aplicar daño al zombie
            other.GetComponent<Barra_vida>().RecibirDaño(CantidadDaño);

            // Destruir la bala después de causar daño
            Destroy(gameObject);
        }
    }
}
