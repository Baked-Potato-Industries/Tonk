using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject cannon;

    private TankData tankData;

    private InputActionMap gunner;
    private InputAction elevate;
    private InputAction traverse;

    [SerializeField] private float elevationAcceleration;
    [SerializeField] private float traversalAcceleration;

    private void Start()
    {
        tankData = transform.root.GetComponent<Tank>().tankData;

        gunner = InputSystem.actions.FindActionMap("Gunner");
        elevate = gunner.FindAction("Elevate");
        traverse = gunner.FindAction("Traverse");

        InitElevationLimit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Elevate(elevate.ReadValue<float>());
        Traverse(traverse.ReadValue<float>());
    }

    private void Elevate(float inputAxis)
    {
        Rigidbody rb = cannon.GetComponent<Rigidbody>();
        float elevateTorque = inputAxis * elevationAcceleration;

        if (rb.angularVelocity.magnitude < tankData.TurretElevationSpeed * Mathf.Deg2Rad)
            rb.AddTorque(turret.transform.right * elevateTorque, ForceMode.Force);
    }

    private void Traverse(float inputAxis)
    {        
        Rigidbody rb = turret.GetComponent<Rigidbody>();

        float traverseTorque = inputAxis * traversalAcceleration;

        if (rb.angularVelocity.magnitude < tankData.TurretElevationSpeed * Mathf.Deg2Rad)
            rb.AddTorque(turret.transform.up * traverseTorque, ForceMode.Force);
    }

    private void InitElevationLimit()
    {
        HingeJoint hinge = cannon.GetComponent<HingeJoint>();
        JointLimits limits = hinge.limits;
        
        limits.min = tankData.TurretElevationLimit.x;
        limits.max = tankData.TurretElevationLimit.y;
        
        hinge.limits = limits;
    }
}
