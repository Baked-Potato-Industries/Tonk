using NaughtyAttributes;
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
public class ShellData : ScriptableObject
{
    [SerializeField] private GameObject model;
    [SerializeField] private ShellType type;

    [Tooltip("Reference armour penetration at 10 meters")]
    [MinValue(0.0f)]
    [SerializeField] private float refPenetration;

    [Tooltip("Size of the shell in mm")]
    [MinValue(0.0f)]
    [SerializeField] private float caliber;

    [Tooltip("Weight of the shell in kg")]
    [MinValue(0.0f)]
    [SerializeField] private float mass;

    [Tooltip("Speed of the shell in m/s")]
    [MinValue(0.0f)]
    [SerializeField] private float muzzleVelocity;

    [Tooltip("Fuze delay in ms (x: min) (y: max)")]
    [MinMaxSlider(0.0f, 30.0f)]
    [SerializeField] private Vector2 fuzeDelay;

    [Tooltip("Fuze sensitivity in mm")]
    [MinValue(0.0f)]
    [SerializeField] private float fuzeSensitivity;

    [SerializeField] private string explosiveType;

    [Tooltip("Explosive mass in grams")]
    [MinValue(0.0f)]
    [SerializeField] private float explosiveMass;

    [Tooltip("TNT equivalence in grams")]
    [MinValue(0.0f)]
    [SerializeField] private float tntEquivalent;

    public GameObject Model => model;
    public ShellType Type => type;
    public float RefPenetration => refPenetration;
    public float Caliber => caliber;
    public float Mass => mass;
    public float MuzzleVelocity => muzzleVelocity;
    public Vector2 FuzeDelay => fuzeDelay;
    public float FuzeSensitivity => fuzeSensitivity;
    public string ExplosiveType => explosiveType;
    public float ExplosiveMass => explosiveMass;
    public float TntEquivalent => tntEquivalent;
}
