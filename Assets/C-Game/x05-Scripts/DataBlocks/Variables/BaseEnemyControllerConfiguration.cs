using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Configuration", menuName = "Base Enemy Controller/Create New Configuration", order = 0)]
public class BaseEnemyControllerConfiguration : ScriptableObject
{
    private Rigidbody2D _rigidbody2D;

    private Vector2 _movementDirection = Vector2.zero;

    [Header("Base Mechanics Settings: ")]
    [SerializeField] private float _interactionRadius;

    [Header("Speed Settings:")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _combatStanceSpeed;
    private float _currentMovementSpeed;

    private bool _isAlive;

    private bool _isCombatStance;
    private bool _isSprinting;
    private bool _isDashing;
    private bool _isMoving;
    private bool _isHoldingWeapon;

    [Header("Health Settings:")]
    [SerializeField] private float _healthIncreaseRate;
    [SerializeField] private float _healthMaximumAmount;
    [SerializeField] private float _healthCurrentAmount;
    [SerializeField] private float _healthRegenerationCooldownTime;

    public Rigidbody2D RB2D { get => _rigidbody2D; set => _rigidbody2D = value; }

    public Vector2 MovementDirection { get => _movementDirection; set => _movementDirection = value; }

    #region Speed
    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    public float SprintSpeed { get => _sprintSpeed; set => _sprintSpeed = value; }
    public float CombatStanceSpeed { get => _combatStanceSpeed; set => _combatStanceSpeed = value; }
    public float CurrentMovementSpeed { get => _currentMovementSpeed; set => _currentMovementSpeed = value; }
    #endregion

    #region Health
    public float HealthIncreaseRate { get => _healthIncreaseRate; set => _healthIncreaseRate = value; }
    public float HealthMaximumAmount { get => _healthMaximumAmount; set => _healthMaximumAmount = value; }
    public float HealthCurrentAmount { get => _healthCurrentAmount; set => _healthCurrentAmount = value; }
    public float HealthRegenerationCooldownTime { get => _healthRegenerationCooldownTime; set => _healthRegenerationCooldownTime = value; }

    public bool IsAlive { get => _isAlive; set => _isAlive = value; }
    #endregion

    #region States
    public bool IsCombatStance { get => _isCombatStance; private set => _isCombatStance = value; }
    public bool IsSprinting { get => _isSprinting; private set => _isSprinting = value; }
    public bool IsDashing { get => _isDashing; private set => _isDashing = value; }
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }
    public bool IsHoldingWeapon { get => _isHoldingWeapon; private set => _isHoldingWeapon = value; }
    #endregion
}