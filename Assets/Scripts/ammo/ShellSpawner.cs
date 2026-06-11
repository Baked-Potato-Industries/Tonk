using System;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public static void FireShell(Transform firePoint, Shell shell)
    {
        var sh = Instantiate(shell.Model, firePoint.position, firePoint.rotation);
        _ = (sh.TryGetComponent(out ShellProjectile sp) ? sp : sh.AddComponent<ShellProjectile>()).shell = shell;
        
    }
}
