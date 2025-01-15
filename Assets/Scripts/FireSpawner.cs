using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab; 
    public Transform player;     
    public float spawnDistance = 10f; 
    private bool fireSpawned = false; 

    public AudioClip thunderSound; 
    private AudioSource audioSource; 

    void Start()
    {
        // Crear un componente AudioSource si no existe
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
    }

    void Update()
    {
        if (!fireSpawned && Vector3.Distance(transform.position, player.position) <= spawnDistance)
        {
            SpawnFire();
        }
    }

    void SpawnFire()
    {
        Instantiate(firePrefab, transform.position, Quaternion.identity);
        PlayThunderSound();
        fireSpawned = true; 
    }

    void PlayThunderSound()
    {
        if (thunderSound != null)
        {
            audioSource.PlayOneShot(thunderSound); 
        }
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnDistance);
    }

  

}

