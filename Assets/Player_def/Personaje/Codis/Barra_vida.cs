using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_vida : MonoBehaviour
{
    public float Salud = 100;
    public float SaludMaxima = 100;

    [Header("Interfaz")]
    public Image BarraSalud;
    public Text TextoSalud;
    public CanvasGroup efectoda�o;

    [Header("Muerto")]
    public GameObject Muerto;

    // Update is called once per frame
    void Update()
    {
        if(efectoda�o.alpha > 0)
        {
            efectoda�o.alpha -= Time.deltaTime;
        }
        ActualizarInterfaz();  
    }

    public void RecibirDa�o(float da�o)
    {
        Salud -= da�o;
        efectoda�o.alpha = 1;

        if(Salud <= 0)
        {
            Instantiate(Muerto);
            Destroy(gameObject);
        }
    }

    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud / SaludMaxima;
        TextoSalud.text = "+" + Salud.ToString("f0");
    }
}
