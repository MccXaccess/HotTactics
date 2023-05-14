using UnityEngine;

public class ModuleStamina : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;

    private float _staminaCooldownTimer = 0.0f;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
    }

    private void Start()
    {
        //characterConfigs.checkStaminaDelegate = CheckStamina;
        //characterConfigs.calculateStaminaDelegate = CalculateStamina;
    }

    private void Update()
    {
        RegenerateStamina();
        DecreaseStamina();
        ClampStamina();
    }

    private void RegenerateStamina()
    {
        if (characterConfigs.IsStaminaIncreaseAllowed)
        {            
            _staminaCooldownTimer += Time.deltaTime;

            if (_staminaCooldownTimer > characterConfigs.StaminaRegenerateCooldownTime &&
                characterConfigs.StaminaCurrentAmount < characterConfigs.StaminaMaximumAmount)
            {
                characterConfigs.StaminaCurrentAmount += characterConfigs.StaminaIncreaseRate * Time.deltaTime;
            }
        }
        else { _staminaCooldownTimer = 0.0f; }
    }

    private void DecreaseStamina()
    {
        if (characterConfigs.IsStaminaDecreaseAllowed)
        {
            characterConfigs.StaminaCurrentAmount -= characterConfigs.StaminaDecreaseRate * Time.deltaTime;
        }
    }

    public bool CalculateStamina(float value)
    {
        _staminaCooldownTimer = 0.0f;

        if (characterConfigs.StaminaCurrentAmount - value >= 0)
        {
            characterConfigs.StaminaCurrentAmount -= value;
            return true;
        }
        return false;
    }

    public bool CheckStamina(float value)
    {
        if (characterConfigs.StaminaCurrentAmount - value >= 0)
        {
            return true;
        }
        return false;
    }

    private void ClampStamina()
    {
        characterConfigs.StaminaCurrentAmount = Mathf.Clamp(characterConfigs.StaminaCurrentAmount, 0.0f, characterConfigs.StaminaMaximumAmount);
    }

    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }

}