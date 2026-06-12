using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    [SerializeField] private List<ShellData> shells;
    [SerializeField] private Transform firePoint;
    [Space]
    [SerializeField] private ShellData loadedShell;
    
    private InputActionMap gunner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunner = InputSystem.actions.FindActionMap("Gunner");

        // don't have to debug.error on my own because it will already throw a null pointer exception
        loadedShell = shells is { Count: > 0} ? shells[0] : null;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gunner.FindAction("Shoot").WasPressedThisFrame())
        {
            Debug.Log("shoot"); 
            Shoot();
        } 
    }

    private void Shoot()
    {
        ShellSpawner.FireShell(firePoint, loadedShell);
    }
}
