using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Shell shell;
    private InputActionMap gunner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunner = InputSystem.actions.FindActionMap("Gunner");
    }

    // Update is called once per frame
    void Update()
    {
        if (gunner.FindAction("Shoot").WasPressedThisFrame())
        {
            Debug.Log("ah!"); 
            Shoot();
        } 
    }

    private void Shoot()
    {
        var sh = Instantiate(shell.Model,transform.position, quaternion.identity);
        
        if (!sh.TryGetComponent(out Rigidbody rb)) 
            rb = sh.AddComponent<Rigidbody>();

        rb.AddForce(Vector3.forward * 100, ForceMode.Impulse);
    }
}
