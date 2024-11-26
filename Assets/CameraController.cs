using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Camera FirstPerson_Camera;
    public Camera ThirdPerson_Camera;
    InputController _inputcontroller;

    bool IsOverheadView;
    // Start is called before the first frame update
    public void ShowOverheadView()
    {
        IsOverheadView = true;
        FirstPerson_Camera.enabled = false;
        ThirdPerson_Camera.enabled = true;
    }
    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView()
    {
        IsOverheadView = false;
        FirstPerson_Camera.enabled = true;
        ThirdPerson_Camera.enabled = false;
    }
    private void Start()
    {
        ShowOverheadView();
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
    private void Update()
    {
        if (ShouldChangeCamera())
        {
            Toggleview();
        }
    }
    private static bool ShouldChangeCamera()
    {
        return Input.GetKeyDown(KeyCode.V);
    }
}