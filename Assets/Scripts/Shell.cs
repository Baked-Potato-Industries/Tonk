using UnityEngine;

public enum ShellType
{
    HE,
    APHE,
    APCBC,
    APHEBC,
    APCR,
}

[CreateAssetMenu(menuName = "Ammo/Shell")]
public class Shell : ScriptableObject
{
    [SerializeField] private GameObject model;
    [SerializeField] private ShellType type;

    [Tooltip("Reference armour penetration at 10 meters")]
    [SerializeField] private float refPenetration;

    [Tooltip("Size of the shell in mm")]
    [SerializeField] private float caliber;

    [Tooltip("Weight of the shell in kg")]
    [SerializeField] private float mass;

    [Tooltip("Speed of the shell in m/s")]
    [SerializeField] private float muzzleVelocity;

    [Tooltip("Fuze delay in m")]
    [SerializeField] private float fuzeDelay;

    [Tooltip("Fuze sensitivity in mm")]
    [SerializeField] private float fuzeSensitivity;

    [SerializeField] private string explosiveType;

    [Tooltip("Explosive mass in grams")]
    [SerializeField] private float explosiveMass;

    [Tooltip("TNT equivalence in grams")]
    [SerializeField] private float tntEquivalent;

    public GameObject Model => model;
    public ShellType Type => type;
    public float RefPenetration => refPenetration;
    public float Caliber => caliber;
    public float Mass => mass;
    public float MuzzleVelocity => muzzleVelocity;
    public float FuzeDelay => fuzeDelay;
    public float FuzeSensitivity => fuzeSensitivity;
    public string ExplosiveType => explosiveType;
    public float ExplosiveMass => explosiveMass;
    public float TntEquivalent => tntEquivalent;
}
