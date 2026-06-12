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
    void FixedUpdate()
    {
        if (gunner.FindAction("Shoot").WasPressedThisFrame())
        {
            Debug.Log("shoot"); 
            Shoot();
        } 
    }

    private void Shoot()
    {
        ShellSpawner.FireShell(transform, shell);
    }
}
