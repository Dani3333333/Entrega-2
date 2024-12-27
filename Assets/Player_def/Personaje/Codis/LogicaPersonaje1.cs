using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    public Animator anim;
    public float x, y;

    // Salto
    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    // Agachado
    public float velocidadInicial;
    public float velocidadAgachado;

    // Apuntar
    private bool apuntando; // Estado de apuntar
    public bool tieneArma; // Estado de si el personaje tiene el arma

    // Items
    public GameObject nearItem;
    public GameObject itemPrefab;
    public Transform itemSlot; // Slot donde se posicionará el arma en el personaje
    public Transform WeaponSlot; // Asigna el WeaponSlot del personaje en el Inspector


    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        apuntando = false;
        tieneArma = false; // Inicialmente no tiene un arma
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }

    // Update is called once per frame
    void Update()
    {
        Movelogic();
        Itemlogic();
    }

    public void Itemlogic()
    {
        // Detectar si el personaje puede recoger el arma
        if (nearItem != null && Input.GetKeyDown(KeyCode.E))
        {
            // Instanciar el arma y posicionarla en el slot
            GameObject instantiatedItem = Instantiate(itemPrefab, WeaponSlot.position, WeaponSlot.rotation);
            Destroy(nearItem.gameObject);

            instantiatedItem.transform.parent = WeaponSlot; // Montar el arma en el WeaponSlot

            tieneArma = true;
            nearItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar cuando el personaje se acerca a un item
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("Hay un item cerca");
            nearItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detectar cuando el personaje se aleja del item
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("Ya no hay un item cerca");
            nearItem = null;
        }
    }

    void Movelogic()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // Salto
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }

            // Agacharse
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("agachado", true);
                velocidadMovimiento = velocidadAgachado;
            }
            else
            {
                anim.SetBool("agachado", false);
                velocidadMovimiento = velocidadInicial;
            }

            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }

        // Apuntar: solo funciona si tiene el arma
        if (tieneArma && Input.GetKey(KeyCode.LeftShift))
        {
            apuntando = true;
            anim.SetBool("apuntar", true);
        }
        else
        {
            apuntando = false;
            anim.SetBool("apuntar", false);
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }
}
