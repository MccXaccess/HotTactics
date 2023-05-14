using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventsController : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    private BaseInputControllerConfiguration inputConfigs;

    private InputBindingsController input = null;

    private void OnEnable()
    {
        input.Character.Movement.performed += ctx => characterConfigs.MovementDirection = ctx.ReadValue<Vector2>();
        input.Character.Movement.canceled += ctx => characterConfigs.MovementDirection = Vector2.zero;

        input.Character.Sprint.performed += ctx => inputConfigs.KeyPressedSprint = ctx.ReadValueAsButton();
        input.Character.Sprint.canceled += ctx => inputConfigs.KeyPressedSprint = ctx.ReadValueAsButton();

        input.Character.Dash.performed += ctx => inputConfigs.KeyPressedDash = ctx.ReadValueAsButton();
        input.Character.Dash.canceled += ctx => inputConfigs.KeyPressedDash = ctx.ReadValueAsButton();

        input.Character.CombatStance.performed += ctx => inputConfigs.KeyPressedCombatStance = ctx.ReadValueAsButton();
        input.Character.CombatStance.canceled += ctx => inputConfigs.KeyPressedCombatStance = ctx.ReadValueAsButton();

        input.Character.Shoot.performed += ctx => inputConfigs.KeyPressedShoot = ctx.ReadValueAsButton();
        input.Character.Shoot.canceled += ctx => inputConfigs.KeyPressedShoot = ctx.ReadValueAsButton();

        input.Character.Interaction.performed += ctx => inputConfigs.KeyPressedInteraction = ctx.ReadValueAsButton();
        input.Character.Interaction.canceled += ctx => inputConfigs.KeyPressedInteraction = ctx.ReadValueAsButton();

        input.Character.Reload.performed += ctx => inputConfigs.KeyPressedReload = ctx.ReadValueAsButton();
        input.Character.Reload.canceled += ctx => inputConfigs.KeyPressedReload = ctx.ReadValueAsButton();
        input.Enable();
    }

    private void OnDisbale()
    {
        input.Character.Movement.performed -= ctx => characterConfigs.MovementDirection = ctx.ReadValue<Vector2>();
        input.Character.Movement.canceled -= ctx => characterConfigs.MovementDirection = Vector2.zero;

        input.Character.Sprint.performed -= ctx => inputConfigs.KeyPressedSprint = ctx.ReadValueAsButton();
        input.Character.Sprint.canceled -= ctx => inputConfigs.KeyPressedSprint = ctx.ReadValueAsButton();

        input.Character.Dash.performed -= ctx => inputConfigs.KeyPressedDash = ctx.ReadValueAsButton();
        input.Character.Dash.canceled -= ctx => inputConfigs.KeyPressedDash = ctx.ReadValueAsButton();

        input.Character.CombatStance.performed -= ctx => inputConfigs.KeyPressedCombatStance = ctx.ReadValueAsButton();
        input.Character.CombatStance.canceled -= ctx => inputConfigs.KeyPressedCombatStance = ctx.ReadValueAsButton();

        input.Character.Shoot.performed -= ctx => inputConfigs.KeyPressedShoot = ctx.ReadValueAsButton();
        input.Character.Shoot.canceled -= ctx => inputConfigs.KeyPressedShoot = ctx.ReadValueAsButton();

        input.Character.Interaction.performed -= ctx => inputConfigs.KeyPressedInteraction = ctx.ReadValueAsButton();
        input.Character.Interaction.canceled -= ctx => inputConfigs.KeyPressedInteraction = ctx.ReadValueAsButton();

        input.Character.Reload.performed -= ctx => inputConfigs.KeyPressedReload = ctx.ReadValueAsButton();
        input.Character.Reload.canceled -= ctx => inputConfigs.KeyPressedReload = ctx.ReadValueAsButton();
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