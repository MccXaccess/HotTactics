using UnityEngine;

// !TEMPLATE! !TEMPLATE! !TEMPLATE! !TEMPLATE! !TEMPLATE! !TEMPLATE! //
// Example on how to use events for modules and stuffs related to    //
// BaseCharacterControllerConfiguration                              //
// !TEMPLATE! !TEMPLATE! !TEMPLATE! !TEMPLATE! !TEMPLATE! !TEMPLATE! //
public class DummyWorkbench : MonoBehaviour
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

    #region Event Listeners
    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }

    private void OnInputValueChanged(BaseInputControllerConfiguration value)
    {
        inputConfigs = value;
    }
    #endregion
}