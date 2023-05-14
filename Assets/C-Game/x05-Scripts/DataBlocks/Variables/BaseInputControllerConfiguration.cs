using UnityEngine;

[CreateAssetMenu(fileName = "Input Configuration", menuName = "Base Input Controller/Create New Configuration", order = 1)]
public class BaseInputControllerConfiguration : ScriptableObject
{
    [Header("Controls Settings:")]
    /*
    [SerializeField] private KeyCode _controlsMovement;
    [SerializeField] private KeyCode _controlsDash;
    [SerializeField] private KeyCode _controlsSprint;
    [SerializeField] private KeyCode _controlsCombatStance;
    */

    private bool _keyPressedMovement;
    private bool _keyPressedDash;
    private bool _keyPressedSprint;
    private bool _keyPressedCombatStance;
    private bool _keyPressedShoot;
    private bool _keyPressedInteraction;
    private bool _keyPressedReload;

    /*
    [SerializeField] private InputActionReference actionMovement;
    [SerializeField] private InputActionReference actionDash;
    [SerializeField] private InputActionReference actionSprint;
    [SerializeField] private InputActionReference actionCombatStance;

    private InputBindingsController input = null;

    public List<InputActionReference> actions = new List<InputActionReference>();

    public InputActionReference ActionMovement { get => actionMovement; set => actionMovement = value; }
    public InputActionReference ActionDash { get => actionDash; set => actionDash = value; }
    public InputActionReference ActionSprint { get => actionSprint; set => actionSprint = value; }
    public InputActionReference ActionCombatStance { get => actionCombatStance; set => actionCombatStance = value; }
    */

    #region KeyPressed
    public bool KeyPressedMovement { get => _keyPressedMovement; set => _keyPressedMovement = value; }
    public bool KeyPressedDash { get => _keyPressedDash; set => _keyPressedDash = value; }
    public bool KeyPressedSprint { get => _keyPressedSprint; set => _keyPressedSprint = value; }
    public bool KeyPressedCombatStance { get => _keyPressedCombatStance; set => _keyPressedCombatStance = value; }
    public bool KeyPressedShoot { get => _keyPressedShoot; set => _keyPressedShoot = value; }
    public bool KeyPressedInteraction { get => _keyPressedInteraction; set => _keyPressedInteraction = value; }
    public bool KeyPressedReload { get => _keyPressedReload; set => _keyPressedReload = value; }
    #endregion 

    #region Controls
    /*
    public KeyCode ControlsMovement { get => _controlsMovement; set => _controlsMovement = value; }
    public KeyCode ControlsDash { get => _controlsDash; set => _controlsDash = value; }
    public KeyCode ControlsSprint { get => _controlsSprint; set => _controlsDash = value; }
    public KeyCode ControlsCombatStance { get => _controlsCombatStance; set => _controlsCombatStance = value; }
    */
    #endregion
}