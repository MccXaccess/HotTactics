using UnityEngine;

[CreateAssetMenu(fileName = "Character Configuration", menuName = "Base Character Controller/Create New Configuration", order = 0)]
public class BaseCharacterControllerConfiguration : ScriptableObject
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

    [Header("Dash Settings:")]
    [Range(1f, 1000f)] [SerializeField] private float _dashForce;
    [Range(1f, 1000f)] [SerializeField] private float _dashMultiplier;
    [Range(0.0f, 15f)] [SerializeField] private float _dashTime;
    [Range(0.0f, 25f)] [SerializeField] private float _dashCooldownTime;

    [Header("Knockback Multiplier Settings:")]
    [Range(1f, 1000f)] [SerializeField] private float _knockbackForce;
    [Range(1f, 1000f)] [SerializeField] private float _knockbackForceMultiplier;

    [Header("Stamina Settings:")]
    [SerializeField] private float _staminaIncreaseRate;
    [SerializeField] private float _staminaDecreaseRate;
    [SerializeField] private float _staminaMaximumAmount;
    [SerializeField] private float _staminaCurrentAmount;
    [SerializeField] private float _staminaRegenerateCooldownTime;

    private bool _isStaminaIncreaseAllowed;
    private bool _isStaminaDecreaseAllowed;

    [Header("Shield Settings:")]
    [SerializeField] private float _shieldIncreaseRate;
    [SerializeField] private float _shieldMaximumAmount;
    [SerializeField] private float _shieldCurrentAmount;
    [SerializeField] private float _shieldRegenerationCooldownTime;

    [Header("Health Settings:")]
    [SerializeField] private float _healthIncreaseRate;
    [SerializeField] private float _healthMaximumAmount;    
    [SerializeField] private float _healthCurrentAmount;
    [SerializeField] private float _healthRegenerationCooldownTime;

    private bool _isAlive;

    // it means how much float number is gonna be used when action happended.
    [Header("Recoil Multiplier Settings:")]
    [SerializeField] private float _recoilSprintMultiplier;
    [SerializeField] private float _recoilWalkMultiplier;
    [SerializeField] private float _recoilDashMultiplier;
    [SerializeField] private float _recoilIdleMultiplier;
    [SerializeField] private float _recoilCombatStanceMultiplier;

    [Header("Recoil Maximum Clamp Settings:")]
    [SerializeField] private float _recoilSprintMaximumClamp;
    [SerializeField] private float _recoilWalkMaximumClamp;
    [SerializeField] private float _recoilDashMaximumClamp;
    [SerializeField] private float _recoilIdleMaximumClamp;
    [SerializeField] private float _recoilCombatStanceMaximumClamp;
    [Space(10)]
    [SerializeField] private float _recoilCurrent;

    [Header("Gun Settings:")]
    [Range(1f, 100f)] [SerializeField] private float _gunShootAccuracy;
    [Range(1f, 100f)] [SerializeField] private float _gunMaxInaccuracy;
    //[Range(10f, 1000f)] [SerializeField] private int _gunMaximumAmmoCapacity;

    private bool _isCombatStance;
    private bool _isSprinting;
    private bool _isDashing;
    private bool _isMoving;
    private bool _isHoldingWeapon;
    

    public Rigidbody2D RB2D { get => _rigidbody2D; set => _rigidbody2D = value; }

    public Vector2 MovementDirection { get => _movementDirection; set => _movementDirection = value; }

    #region Base Mechanics
    public float InteractionRadius { get => _interactionRadius; set => _interactionRadius = value; }
    #endregion

    #region Speed
    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    public float SprintSpeed { get => _sprintSpeed; set => _sprintSpeed = value; }
    public float CombatStanceSpeed { get => _combatStanceSpeed; set => _combatStanceSpeed = value; }
    public float CurrentMovementSpeed { get => _currentMovementSpeed; set => _currentMovementSpeed = value; }
    #endregion

    #region Dash
    public float DashForce { get => _dashForce; set => _dashForce = value; }
    public float DashMultiplier { get => _dashMultiplier; set => _dashMultiplier = value; }
    public float DashTime { get => _dashTime; set => _dashTime = value; }
    public float DashCooldownTime { get => _dashCooldownTime; set => _dashCooldownTime = value; }
    #endregion

    #region Knockback
    public float KnockbackForce { get => _knockbackForce; set => _knockbackForce = value; }
    public float KnockbackForceMultiplier { get => _knockbackForceMultiplier; set => _knockbackForceMultiplier = value; }
    #endregion

    #region Stamina
    public float StaminaIncreaseRate { get => _staminaIncreaseRate; set => _staminaIncreaseRate = value; }
    public float StaminaDecreaseRate { get => _staminaDecreaseRate; set => _staminaDecreaseRate = value; }
    public float StaminaMaximumAmount { get => _staminaMaximumAmount; set => _staminaMaximumAmount = value; }
    public float StaminaCurrentAmount { get => _staminaCurrentAmount; set => _staminaCurrentAmount = value; }
    public float StaminaRegenerateCooldownTime { get => _staminaRegenerateCooldownTime; set => _staminaRegenerateCooldownTime = value; }

    public bool IsStaminaIncreaseAllowed { get => _isStaminaIncreaseAllowed; set => _isStaminaIncreaseAllowed = value; }
    public bool IsStaminaDecreaseAllowed { get => _isStaminaDecreaseAllowed; set => _isStaminaDecreaseAllowed = value; }
    #endregion

    #region Shield
    public float ShieldIncreaseRate { get => _shieldIncreaseRate; set => _shieldIncreaseRate = value; }
    public float ShieldMaximumAmount { get => _shieldMaximumAmount; set => _shieldMaximumAmount = value; }
    public float ShieldCurrentAmount { get => _shieldCurrentAmount; set => _shieldCurrentAmount = value; }
    public float ShieldRegenerationCooldownTime { get => _shieldRegenerationCooldownTime; set => _shieldRegenerationCooldownTime = value; }
    #endregion

    #region Health
    public float HealthIncreaseRate { get => _healthIncreaseRate; set => _healthIncreaseRate = value; }
    public float HealthMaximumAmount { get => _healthMaximumAmount; set => _healthMaximumAmount = value; }
    public float HealthCurrentAmount { get => _healthCurrentAmount; set => _healthCurrentAmount = value; }
    public float HealthRegenerationCooldownTime { get => _healthRegenerationCooldownTime; set => _healthRegenerationCooldownTime = value; }

    public bool IsAlive { get => _isAlive; set => _isAlive = value; }
    #endregion

    #region Recoil
    public float RecoilSprintMultiplier { get => _recoilSprintMultiplier; set => _recoilSprintMultiplier = value; }
    public float RecoilWalkMultiplier { get => _recoilWalkMultiplier; set => _recoilWalkMultiplier = value; }
    public float RecoilDashMultiplier { get => _recoilDashMultiplier; set => _recoilDashMultiplier = value; }
    public float RecoilIdleMultiplier { get => _recoilIdleMultiplier; set => _recoilIdleMultiplier = value; }
    public float RecoilCombatStanceMultiplier { get => _recoilCombatStanceMultiplier; set => _recoilCombatStanceMultiplier = value; }

    public float RecoilSprintMaximumClamp { get => _recoilSprintMaximumClamp; set => _recoilSprintMaximumClamp = value; }
    public float RecoilWalkMaximumClamp { get => _recoilWalkMaximumClamp; set => _recoilWalkMaximumClamp = value; }
    public float RecoilDashMaximumClamp { get => _recoilDashMaximumClamp; set => _recoilDashMaximumClamp = value; }
    public float RecoilIdleMaximumClamp { get => _recoilIdleMaximumClamp; set => _recoilIdleMaximumClamp = value; }
    public float RecoilCombatStanceMaximumClamp { get => _recoilCombatStanceMaximumClamp; set => _recoilCombatStanceMaximumClamp = value; }

    public float RecoilCurrent { get => _recoilCurrent; set => _recoilCurrent = value; }
    #endregion

    #region Gun
    public float GunShootAccuracy { get => _gunShootAccuracy; set => _gunShootAccuracy = value; }
    // like a debug from a gun itself so if a character has 100% accuracy the inaccuracy is a debuff?
    //public float GunMaxInaccuracy { get => _gunMaxInaccuracy; set => _gunMaxInaccuracy = value; }
    //public int GunMaximumAmmoCapacity { get => _gunMaximumAmmoCapacity; set => _gunMaximumAmmoCapacity = value; }
    #endregion

    #region States
    public bool IsCombatStance { get => _isCombatStance; private set => _isCombatStance = value; }
    public bool IsSprinting { get => _isSprinting; private set => _isSprinting = value; }
    public bool IsDashing { get => _isDashing; private set => _isDashing = value; }
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }
    public bool IsHoldingWeapon { get => _isHoldingWeapon; private set => _isHoldingWeapon = value; }
    #endregion
}