using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera FirstPerson_Camera;
    public Camera ThirdPerson_Camera;
    public Transform cameraTarget; // Objetivo de la c�mara (puede ser la cabeza del personaje)
    public float smoothSpeed = 5f; // Velocidad de interpolaci�n para los movimientos

    private bool IsOverheadView;
    private LogicaPersonaje1 characterLogic;

    private Vector3 defaultOffset; // Desplazamiento inicial desde el personaje
    private Vector3 crouchOffset;  // Desplazamiento cuando se agacha
    private Vector3 jumpOffset;    // Desplazamiento cuando salta

    private void Start()
    {
        ShowOverheadView();

        // Buscar el personaje y obtener la l�gica asociada
        characterLogic = FindObjectOfType<LogicaPersonaje1>();

        // Configurar los desplazamientos
        defaultOffset = new Vector3(0, 1.5f, -2f); // Ajusta seg�n la posici�n normal
        crouchOffset = new Vector3(0, 0.8f, -2f);  // M�s bajo cuando est� agachado
        jumpOffset = new Vector3(0, 2.0f, -2f);    // M�s alto cuando salta
    }

    private void Update()
    {
        if (ShouldChangeCamera())
        {
            Toggleview();
        }

        if (!IsOverheadView) // Solo mover la c�mara si est� en vista en primera o tercera persona
        {
            AdjustCameraPosition();
        }
    }

    public void ShowOverheadView()
    {
        IsOverheadView = true;
        FirstPerson_Camera.enabled = false;
        ThirdPerson_Camera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        IsOverheadView = false;
        FirstPerson_Camera.enabled = true;
        ThirdPerson_Camera.enabled = false;
    }

    void Toggleview()
    {
        if (IsOverheadView)
        {
            ShowFirstPersonView();
        }
        else
        {
            ShowOverheadView();
        }
    }

    private static bool ShouldChangeCamera()
    {
        return Input.GetKeyDown(KeyCode.V);
    }

    private void AdjustCameraPosition()
    {
        if (characterLogic == null) return;

        // Determinar el offset seg�n el estado del personaje
        Vector3 targetOffset = defaultOffset;

        if (characterLogic.anim.GetBool("agachado"))
        {
            targetOffset = crouchOffset;
        }
        else if (!characterLogic.puedoSaltar && !characterLogic.anim.GetBool("tocoSuelo"))
        {
            targetOffset = jumpOffset;
        }

        // Interpolar la posici�n de la c�mara
        Vector3 desiredPosition = characterLogic.transform.position + targetOffset;
        ThirdPerson_Camera.transform.position = Vector3.Lerp(ThirdPerson_Camera.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Mantener la c�mara mirando al personaje
        ThirdPerson_Camera.transform.LookAt(cameraTarget);
    }
}
