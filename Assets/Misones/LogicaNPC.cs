using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
using TMPro;

public class LogicaNPC : MonoBehaviour
{
    public GameObject simboloMision;
    public GameObject panelNPC1;
    public GameObject panelNPC2;
    public GameObject panelNPC3;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonMision;
    public GameObject panelNPC;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text = "¿Papá?, eres tú? Creo haber visto a mamá en sueños... Necesito la cura papá, tienes que conseguir la llave de casa antes que nada..." +
                           

        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje1>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && aceptarMision == false && jugador.puedoSaltar == true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);

            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }



        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarMision == false)
            {
                panelNPC.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                jugadorCerca = false;
                panelNPC.SetActive(false);
                panelNPC2.SetActive(false);
            }
        }

        public void No()
        {
            jugador.enabled = true;
            panelNPC2.SetActive(false);
            panelNPC.SetActive(true);
        }

        public void Si()
        {
            jugador.enabled = true;
            aceptarMision = true;
            for (int i = 0; i < objetivos.Length; i++)
            {
                objetivos[i].SetActive(true);
            }
            jugadorCerca = false;
            simboloMision.SetActive(false);
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
            panelNPCMision.SetActive(true);
        }

    }

}

