using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    [SerializeField] private int _characterID;
    [SerializeField] private int _characterKills;
    
    public int CharacterKills { get => _characterKills; set => _characterKills = value; }

    private void OnEnable()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        Debug.Log("Instance of " + this.gameObject.name + " has been enabled!");
    }

    private void OnDisable()
    {
        EventHandler.CurrentCharacterConfigs = null;
        Debug.Log("Instance of " + this.gameObject.name + " has been disabled!");
    }

    private void Awake()
    {
        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged); 
        EventHandler.SwitchCharacter(_characterID);

        #region Initial Properties Set
        characterConfigs.HealthCurrentAmount = characterConfigs.HealthMaximumAmount;
        characterConfigs.StaminaCurrentAmount = characterConfigs.StaminaMaximumAmount;
        characterConfigs.ShieldCurrentAmount = characterConfigs.ShieldMaximumAmount;
        characterConfigs.RecoilCurrent = 0.0f;
        
        CharacterKills = 0;
        
        characterConfigs.SetBoolean("IsAlive", true);
        #endregion
    }

    private void Start()
    {
        characterConfigs.RB2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        EventHandler.SwitchCharacter(_characterID);
    }

    private void FixedUpdate()
    {
        if (characterConfigs.IsMoving)
        {
            characterConfigs.RB2D.velocity = characterConfigs.MovementDirection * characterConfigs.CurrentMovementSpeed;
        }
    }

    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }
}