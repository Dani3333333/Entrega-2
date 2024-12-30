using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public GameObject dialogPanel; // Panel del diálogo en la UI
    public Button acceptButton;   // Botón del Canvas para aceptar
    public GameObject weaponObject; // Objeto del arma en la escena
    public GameObject npcIcon;   // El cilindro (icono) sobre el NPC

    private bool isPlayerNear = false; // Para saber si el jugador está cerca

    void Start()
    {
        dialogPanel.SetActive(false); // Ocultar el diálogo al inicio
        weaponObject.SetActive(false); // Asegurarse de que el arma esté oculta al inicio
        acceptButton.onClick.AddListener(MakeWeaponVisible); // Asociar el botón con la función
    }

    void Update()
    {
        if (isPlayerNear) // Si el jugador está cerca, mostrar el diálogo
        {
            dialogPanel.SetActive(true);
        }
        else
        {
            dialogPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Comprobar si es el jugador
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false; // El jugador ya no está cerca
        }
    }

    void MakeWeaponVisible()
    {
        weaponObject.SetActive(true); // Hacer visible el arma
        npcIcon.SetActive(false); // Ocultar el icono del NPC
        dialogPanel.SetActive(false); // Ocultar el panel del diálogo
    }
}

