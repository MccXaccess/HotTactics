using UnityEngine;
using System;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    private BaseInputControllerConfiguration inputConfigs;
    private BaseGunControllerConfiguration currentGunConfigs;

    public event Action<float> onReload;
    public event Action onShoot;
    public event Action onDrop;
    public event Action onPickup;

    public ModuleInteraction moduleInteraction;
    public ModuleAttack moduleShoot;

    [SerializeField] private GameObject _activeField;
    [SerializeField] private GameObject _passiveField;

    [SerializeField] private LayerMask _layerMaskWeapon;

    private GameObject _currentWeapon;
    private GunController gun;

    private float _currentShootCooldownTime;
    private float _currentShootReloadTime;

    private Collider2D collision;

    public GunController Gun => gun;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        inputConfigs = EventHandler.CurrentInputConfigs;

        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
        EventHandler.onInputSwitchedEvent.AddListener(OnInputValueChanged); 
    }

    private void OnEnable()
    {
        ExtensionSetCoroutine.SubscribeToCoroutineActions(HandleCoroutineEvent);
        onPickup += HandlePickupEvent;
        onDrop += HandleDropEvent;
    }

    private void OnDisable()
    {
        ExtensionSetCoroutine.UnsubscribeFromCoroutineActions(HandleCoroutineEvent);
        onPickup -= HandlePickupEvent;
        onDrop -= HandleDropEvent;
    }

    private void Update()
    {
        if (_currentWeapon == null)
        {
            characterConfigs.SetBoolean("IsHoldingWeapon", false);
        }

        if (inputConfigs.KeyPressedInteraction)
        {
            inputConfigs.SetBoolean("KeyPressedInteraction", false);

            collision = Physics2D.OverlapCircle(transform.position, characterConfigs.InteractionRadius, _layerMaskWeapon);

            gun = collision?.gameObject.GetComponent<GunController>();

            #region Interactions : Pickup / Switch / Drop
            if (_currentWeapon == null && collision != null)
            {
                onPickup?.Invoke();
                DebugOutput.Log("Picked up a", $"{_currentWeapon}");
            }

            else if (_currentWeapon != null && collision != null)
            {
                onDrop?.Invoke();
                onPickup?.Invoke();
            }

            else if (_currentWeapon != null && characterConfigs.IsHoldingWeapon)
            {
                onDrop?.Invoke();
            }
            #endregion
        }

        if (_currentWeapon != null)
        {
            if (inputConfigs.KeyPressedShoot)
            {
                onShoot?.Invoke();
            }

            if (inputConfigs.KeyPressedReload && gun.GunTotalAmmo + gun.GunMagCurrentAmmo >= currentGunConfigs.GunMagMaximumAmmo)
            {
                onReload?.Invoke(currentGunConfigs.GunReloadTime);
            }

            _currentShootCooldownTime -= Time.deltaTime;
        }
    }

    public void FixedUpdate()
    {
        
    }

    #region Event Listeners
    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }

    private void OnInputValueChanged(BaseInputControllerConfiguration value)
    {
        inputConfigs = value;
    }

    private void HandleReloadEvent(float duration)
    {
        inputConfigs.SetBoolean("KeyPressedReload", false);
        StartCoroutine(duration.SetCoroutineWait());
    }

    private void HandleShootEvent()
    {
        if (_currentShootCooldownTime > 0.0f || gun.GunMagCurrentAmmo <= 0.0f) return;
        
        // NOTE : USELESS PIECE OF CODE, FOR NOW...
        Vector3 rotation = transform.GetRotationFromToCursor();

        moduleShoot.GunShoot(currentGunConfigs.GunBulletPrefab, gun.GunShootPoint.transform.position, gun.GunShootPoint.transform.rotation, currentGunConfigs.GunOffset, characterConfigs.RecoilCurrent, characterConfigs.GunShootAccuracy);
        //moduleShoot.GunShootModified(currentGunConfigs.GunBulletPrefab, gun.GunShootPoint.transform.position, this.transform, rotation, characterConfigs.RecoilCurrent, characterConfigs.GunShootAccuracy);
        characterConfigs.RecoilCurrent = characterConfigs.RecoilCurrent < currentGunConfigs.RecoilMaximum ? characterConfigs.RecoilCurrent += currentGunConfigs.GunOnShootRecoilIncrease : characterConfigs.RecoilCurrent;

        inputConfigs.KeyPressedShoot = currentGunConfigs.GunAutoEnabled;

        _currentShootCooldownTime = currentGunConfigs.GunShootCooldown;

        gun.GunMagCurrentAmmo -= 1;   
    }

    private void HandlePickupEvent()
    {
        onReload += HandleReloadEvent;

        onShoot += HandleShootEvent;

        currentGunConfigs = gun.gunConfigs;

        characterConfigs.SetBoolean("IsHoldingWeapon", true);

        moduleInteraction.PickUp(ref _currentWeapon, _activeField, collision, currentGunConfigs.GunOffset);
    }

    private void HandleDropEvent()
    {
        onReload -= HandleReloadEvent;

        onShoot -= HandleShootEvent;

        characterConfigs.SetBoolean("IsHoldingWeapon", false);

        moduleInteraction.Drop(ref _currentWeapon, ref _activeField, collision);
    }

    private void HandleCoroutineEvent()
    {
        gun.GunTotalAmmo -= (currentGunConfigs.GunMagMaximumAmmo - gun.GunMagCurrentAmmo);
        gun.GunMagCurrentAmmo = currentGunConfigs.GunMagMaximumAmmo;
    }
    #endregion
}