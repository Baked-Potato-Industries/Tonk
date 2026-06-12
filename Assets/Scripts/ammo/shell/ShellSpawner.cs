using System;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public static void FireShell(Transform firePoint, ShellData shell)
    {
        var sh = Instantiate(shell.Model, firePoint.position, firePoint.rotation);
        _ = (sh.TryGetComponent(out Shell sp) ? sp : sh.AddComponent<Shell>()).shellData = shell;
        
    }
}
