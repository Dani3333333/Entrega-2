//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class CameraController : MonoBehaviour
//{
//    public Camera FirstPerson_Camera;
//    public Camera ThirdPerson_Camera;
//    InputController _inputcontroller;

//    bool IsOverheadView;
//    // Start is called before the first frame update
//    public void ShowOverheadView()
//    {
//        IsOverheadView = true;
//        FirstPerson_Camera.enabled = false;
//        ThirdPerson_Camera.enabled = true;
//    }
//    // Call this function to enable FPS camera,
//    // and disable overhead camera.
//    public void ShowFirstPersonView()
//    {
//        IsOverheadView = false;
//        FirstPerson_Camera.enabled = true;
//        ThirdPerson_Camera.enabled = false;
//    }
//    private void Start()
//    {
//        ShowOverheadView();
//    }
//    void Toggleview()
//    {
//        if (IsOverheadView)
//        {
//            ShowFirstPersonView();
//        }
//        else
//        {
//            ShowOverheadView();
//        }
//    }
//    private void Update()
//    {
//        if (ShouldChangeCamera())
//        {
//            Toggleview();
//        }
//    }
//    private static bool ShouldChangeCamera()
//    {
//        return Input.GetKeyDown(KeyCode.V);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera FirstPerson_Camera;
    public Camera ThirdPerson_Camera;

    public float mouseSensitivity = 100f; // Sensibilidad del ratón
    public Transform playerBody; // Referencia al cuerpo del jugador

    private float pitch = 0f; // Para limitar la rotación vertical
    private bool isOverheadView = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
        ShowOverheadView();
    }

    void Update()
    {
        // Movimiento de la cámara con el ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (isOverheadView)
        {
            // Movimiento de la cámara en tercera persona
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -30f, 60f); // Limitar el ángulo vertical

            ThirdPerson_Camera.transform.localEulerAngles = new Vector3(pitch, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            // Movimiento de la cámara en primera persona
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -90f, 90f); // Limitar el ángulo vertical

            FirstPerson_Camera.transform.localEulerAngles = new Vector3(pitch, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        // Cambiar entre cámaras con la tecla "V"
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleView();
        }
    }

    public void ShowOverheadView()
    {
        isOverheadView = true;
        FirstPerson_Camera.enabled = false;
        ThirdPerson_Camera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        isOverheadView = false;
        FirstPerson_Camera.enabled = true;
        ThirdPerson_Camera.enabled = false;
    }

    void ToggleView()
    {
        if (isOverheadView)
        {
            ShowFirstPersonView();
        }
        else
        {
            ShowOverheadView();
        }
    }
}
