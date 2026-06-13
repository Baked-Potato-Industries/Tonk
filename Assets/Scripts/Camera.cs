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
    private GameObject body;
    private GameObject cannon;

    private InputActionMap cameraActionMap;

    [SerializeField] private CamMode camMode = CamMode.Shoot;

    [SerializeField] private float shootCamOffset = 0.035f;
    [SerializeField] private Vector2 hoverCamOffset = new Vector2(0.03f, -0.08f);

    // serialized for debug purposes
    //[SerializeField] private Vector3 targetCamPos = Vector3.zero;
    //[SerializeField] private Quaternion targetCamRotation = Quaternion.identity;


    void Start()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        cameraActionMap = InputSystem.actions.FindActionMap("Camera");
        body = tank.transform.Find("body").gameObject;
        cannon = body.transform.Find("turret").Find("cannon").gameObject;

        HandleCamSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        DetectCamSwitch(cameraActionMap.FindAction("Switch"));
    }

    void DetectCamSwitch(InputAction camSwitchAction)
    {
        if(camSwitchAction.WasPressedThisFrame())
        {
            camMode = (CamMode)(((int)camMode + 1) % Enum.GetValues(typeof(CamMode)).Length);
            HandleCamSwitch();
        }
    }

    void HandleCamSwitch()
    {
        switch (camMode)
        {
            case CamMode.Shoot:
                transform.SetParent(cannon.transform, false);
                transform.localPosition = new Vector3(0.0f, 0.0f, shootCamOffset);
                transform.localRotation = Quaternion.identity;

                break;

            case CamMode.Hover:
                transform.SetParent(body.transform, false);
                transform.localPosition = new Vector3(0.0f, hoverCamOffset.x, hoverCamOffset.y);
                transform.localRotation = Quaternion.Euler(15.0f, 0.0f, 0.0f);
                break;
        }
    }

}
