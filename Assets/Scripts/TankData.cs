using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Vehicle/Tank")]
public class TankData : ScriptableObject
{
    [MinValue(0.0f)]
    [SerializeField] private float forwardMaxSpeed;
    
    [MinValue(0.0f)]
    [SerializeField] private float backwardMaxSpeed;

    [MinValue(0.0f)]
    [SerializeField] private float weight;

    [MinMaxSlider(-90.0f, 90.0f)]
    [SerializeField] private Vector2 turretElevationLimit;

    [MinValue(0.0f)]
    [SerializeField] private float turretTraverseSpeed;

    [MinValue(0.0f)]
    [SerializeField] private float turretElevationSpeed;

    public float ForwardMaxSpeed => forwardMaxSpeed;
    public float BackwardMaxSpeed => backwardMaxSpeed;
    public float Weight => weight;
    public Vector2 TurretElevationLimit => turretElevationLimit;
    public float TurretTraverseSpeed => turretTraverseSpeed;
    public float TurretElevationSpeed => turretElevationSpeed;
}