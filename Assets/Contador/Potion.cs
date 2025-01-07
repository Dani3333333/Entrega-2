using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject objetoPocion; 
    public TimerController timerController; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (timerController != null)
            {
                timerController.StartTimer(); 
            }
            Destroy(objetoPocion); 
        }
    }
}
