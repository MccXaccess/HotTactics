using System;
using UnityEngine;
using UnityEngine.InputSystem;

using static UnityEngine.InputSystem.InputAction;

public class InputEventsController : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    private BaseInputControllerConfiguration inputConfigs;

    private InputBindingsController input = null;

    void UpdateKeyPressedSprint(CallbackContext ctx) => inputConfigs.KeyPressedSprint = ctx.ReadValueAsButton();
    void UpdateKeyPressedDash(CallbackContext ctx) => inputConfigs.KeyPressedDash = ctx.ReadValueAsButton();
    void UpdateKeyPressedCombatStance(CallbackContext ctx) => inputConfigs.KeyPressedCombatStance = ctx.ReadValueAsButton();
    void UpdateKeyPressedShoot(CallbackContext ctx) => inputConfigs.KeyPressedShoot = ctx.ReadValueAsButton();
    void UpdateKeyPressedInteraction(CallbackContext ctx) => inputConfigs.KeyPressedInteraction = ctx.ReadValueAsButton();
    void UpdateKeyPressedReload(CallbackContext ctx) => inputConfigs.KeyPressedReload = ctx.ReadValueAsButton();
    void UpdateMovementDirection(CallbackContext ctx) => characterConfigs.MovementDirection = ctx.ReadValue<Vector2>();
    void ResetMovementDirection(CallbackContext ctx) => characterConfigs.MovementDirection = Vector2.zero;

    private void OnEnable()
    {
        input.Character.Movement.performed += UpdateMovementDirection;
        input.Character.Movement.canceled += ResetMovementDirection;

        input.Character.Sprint.performed += UpdateKeyPressedSprint;
        input.Character.Sprint.canceled += UpdateKeyPressedSprint;

        input.Character.Dash.performed += UpdateKeyPressedDash;
        input.Character.Dash.canceled += UpdateKeyPressedDash;

        input.Character.CombatStance.performed += UpdateKeyPressedCombatStance;
        input.Character.CombatStance.canceled += UpdateKeyPressedCombatStance;

        input.Character.Shoot.performed += UpdateKeyPressedShoot;
        input.Character.Shoot.canceled += UpdateKeyPressedShoot;

        input.Character.Interaction.performed += UpdateKeyPressedInteraction;
        input.Character.Interaction.canceled += UpdateKeyPressedInteraction;

        input.Character.Reload.performed += UpdateKeyPressedReload;
        input.Character.Reload.canceled += UpdateKeyPressedReload;
        input.Enable();
    }

    private void OnDisable()
    {
        input.Character.Movement.performed -= UpdateMovementDirection;
        input.Character.Movement.canceled -= ResetMovementDirection;

        input.Character.Sprint.performed -= UpdateKeyPressedSprint;
        input.Character.Sprint.canceled -= UpdateKeyPressedSprint;

        input.Character.Dash.performed -= UpdateKeyPressedDash;
        input.Character.Dash.canceled -= UpdateKeyPressedDash;

        input.Character.CombatStance.performed -= UpdateKeyPressedCombatStance;
        input.Character.CombatStance.canceled -= UpdateKeyPressedCombatStance;

        input.Character.Shoot.performed -= UpdateKeyPressedShoot;
        input.Character.Shoot.canceled -= UpdateKeyPressedShoot;

        input.Character.Interaction.performed -= UpdateKeyPressedInteraction;
        input.Character.Interaction.canceled -= UpdateKeyPressedInteraction;

        input.Character.Reload.performed -= UpdateKeyPressedReload;
        input.Character.Reload.canceled -= UpdateKeyPressedReload;
        input.Disable();
    }

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        inputConfigs = EventHandler.CurrentInputConfigs;
        
        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
        EventHandler.onInputSwitchedEvent.AddListener(OnInputValueChanged);
        input = new InputBindingsController();
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