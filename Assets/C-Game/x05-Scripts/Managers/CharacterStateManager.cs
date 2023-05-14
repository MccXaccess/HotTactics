using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    
    private BaseCharacterStateAbstract currentState;

    public IdleState IdleState;
    public WalkState WalkState;
    public DashState DashState;
    public SprintState SprintState;
    public CombatStanceState CombatStanceState;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        EventHandler.onCharacterSwitchedEvent.AddListener(OnValueChanged);
    }

    private void Start()
    {
        IdleState = new IdleState(characterConfigs);
        WalkState = new WalkState(characterConfigs);
        DashState = new DashState(characterConfigs);
        SprintState = new SprintState(characterConfigs);
        CombatStanceState = new CombatStanceState(characterConfigs);
        
        currentState = IdleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    // takes the current bool state to set that to false
    public void SwitchState(BaseCharacterStateAbstract state)
    {
        state.ExitState(this);

        currentState = state;
        
        state.EnterState(this);
    }

    private void OnValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }
}