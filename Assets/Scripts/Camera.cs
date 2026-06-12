using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    enum CamMode
    {
        Shoot,
        Hover
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject tank;
    private GameObject cannon;

    private InputActionMap cameraActionMap;

    [SerializeField] private CamMode camMode = CamMode.Shoot;

    // serialized for debug purposes
    [SerializeField] private Vector3 targetCamPos = Vector3.zero;
    [SerializeField] private Quaternion targetCamRotation = Quaternion.identity;

    void Start()
    {
        cameraActionMap = InputSystem.actions.FindActionMap("Camera");
        cannon = tank.transform.Find("turret").Find("cannon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DetectCamSwitch(cameraActionMap.FindAction("Switch"));
        MoveCamera();
        
    }

    void DetectCamSwitch(InputAction camSwitchAction)
    {
        if(camSwitchAction.WasPressedThisFrame())
        {
            camMode = (CamMode)(((int)camMode + 1) % Enum.GetValues(typeof(CamMode)).Length);
        }
    }

    void MoveCamera()
    {
        switch (camMode)
        {
            case CamMode.Shoot:
                targetCamPos = cannon.transform.position;
                break;
            case CamMode.Hover:
                break;
        }
    }

}
