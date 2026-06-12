using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject cannon;

    private InputActionMap gunner;
    private InputAction elevate;
    private InputAction traverse;

    [SerializeField] private float elevateTorquePower = 500.0f;
    public float maxAscendAngle = 30.0f;
    public float maxDescendAngle = -3.0f;
    [SerializeField] private float traverseTorquePower = 6000.0f;

    //debug

    [SerializeField] private float elevateTorque = 0.0f;
    [SerializeField] private float traverseTorque = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunner = InputSystem.actions.FindActionMap("Gunner");
        elevate = gunner.FindAction("Elevate");
        traverse = gunner.FindAction("Traverse");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float cannonAngle = cannon.transform.localRotation.eulerAngles.y;
        elevateTorque = elevateTorquePower * elevate.ReadValue<float>() * Time.fixedDeltaTime;

        // the angles are so fucked for no reason i'm leaving the limiting code to the next poor sod who has to look at this

        cannon.GetComponent<Rigidbody>().AddTorque(turret.transform.up * elevateTorque, ForceMode.Force);

        traverseTorque = traverseTorquePower * traverse.ReadValue<float>() * Time.fixedDeltaTime;
        turret.GetComponent<Rigidbody>().AddTorque(Vector3.up * traverseTorque, ForceMode.Force);
    }
}
