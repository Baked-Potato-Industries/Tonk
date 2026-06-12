using System.Collections;
using System.Linq;
using UnityEngine;

public class ShellProjectile : MonoBehaviour
{
    public Shell shell { get; set; }
    public static readonly int FUZE_DELAY_AVERAGE = 12;

    private Rigidbody rb;

    void Start()
    {   
        if (!TryGetComponent(out rb)) rb = gameObject.AddComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * shell.MuzzleVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Shell hit: {collision.gameObject.name}");
        Debug.Log($"fuze in {shell.FuzeDelay} ms");
        StartCoroutine(destruct());
    }
    
    private IEnumerator destruct()
    {
        float delay = Enumerable.Range(0, FUZE_DELAY_AVERAGE).Average(_ => Random.Range(shell.FuzeDelay.x, shell.FuzeDelay.y));
        yield return new WaitForSeconds(delay / 1000);

        Debug.Log("boom!");

        Destroy(gameObject);
    }

    public bool CanPenetrate(Collision hit)
    {
        var armour = hit.gameObject.GetComponent<Armour>();
        if (armour == null) return false;

        var contact = hit.GetContact(0);
        float angle = Vector3.Angle(contact.point, contact.normal);

        float penetration = shell.RefPenetration * Mathf.Pow(hit.relativeVelocity.magnitude / shell.MuzzleVelocity, 1.4283f);

        return penetration < armour.thickness / Mathf.Cos(angle);
    }
}
