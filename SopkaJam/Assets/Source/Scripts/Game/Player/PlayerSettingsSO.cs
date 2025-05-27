using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "Player Settings")]
public class PlayerSettingsSO : ScriptableObject
{
    [Header("Movment Settings")]
    [SerializeField] private float _movmentSpeed;
    [Header("Dash Settings")]
    [SerializeField] private float _dashForce;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _dashTime;
    [SerializeField] private float _slowMotionFactor;

    public float MovmentSpeed => _movmentSpeed;
    public float DashForce => _dashForce;
    public float DashCooldown => _cooldown;
    public float DashTime => _dashTime;
    public float SlowMotionFactor => _slowMotionFactor;
}
