using UnityEngine;

public class InputFilterController : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    private BaseInputControllerConfiguration inputConfigs;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        inputConfigs = EventHandler.CurrentInputConfigs;

        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
        EventHandler.onInputSwitchedEvent.AddListener(OnInputValueChanged);
    }

    private void Update()
    {
        MovementPriority();
    }

    private void TurnOff()
    {
        characterConfigs.SetBoolean("IsDashing", false);
        characterConfigs.SetBoolean("IsCombatStance", false);
        characterConfigs.SetBoolean("IsSprinting", false);
    }

    private void MovementPriority()
    {
        TurnOff();
        // NOTE : use switch case here?
        if (inputConfigs.KeyPressedDash)
        {
            characterConfigs.SetBoolean("IsDashing", true);
        }

        if (inputConfigs.KeyPressedCombatStance) 
        {
            characterConfigs.SetBoolean("IsCombatStance", true);
        }

        else if (inputConfigs.KeyPressedSprint) 
        {
            characterConfigs.SetBoolean("IsSprinting", true);
        }
    }

    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }

    private void OnInputValueChanged(BaseInputControllerConfiguration value)
    {
        inputConfigs = value;
    }
}