using UnityEngine;

public class ModuleInMotion : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    private BaseInputControllerConfiguration inputConfigs;

    private float _timerMaximum = 0.3f;
    private float _timerCurrent = 0.0f;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        inputConfigs = EventHandler.CurrentInputConfigs;

        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
        EventHandler.onInputSwitchedEvent.AddListener(OnInputValueChanged);
    }

    private void Update()
    {
        CheckMotion();
    }

    private void CheckMotion()
    {
        if(characterConfigs.MovementDirection == Vector2.zero)
        {
            _timerCurrent -= Time.deltaTime;

            if (_timerCurrent < 0.0f)
            {
                characterConfigs.SetBoolean("IsMoving", false);
            }
        }
        else { _timerCurrent = _timerMaximum; characterConfigs.SetBoolean("IsMoving", true); }
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