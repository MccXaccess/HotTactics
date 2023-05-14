using UnityEngine;

[CreateAssetMenu(fileName = "Event Handler", menuName = "Event Handlers/Create New Switch Event Handler", order = 0)]
public class BaseEventHandler : ScriptableObject
{
    public BaseCharacterControllerConfiguration currentCharacterConfigs;
    public BaseInputControllerConfiguration currentInputConfigs;
    public BaseGunControllerConfiguration currentWeaponConfigs;

    public SOEvents.OnCharacterSwitched onCharacterSwitchedEvent = new SOEvents.OnCharacterSwitched();
    public SOEvents.OnInputSwitched onInputSwitchedEvent = new SOEvents.OnInputSwitched();
    public SOEvents.OnWeaponSwitched onWeaponSwitchedEvent = new SOEvents.OnWeaponSwitched();

    [SerializeField] private BaseCharacterControllerConfiguration[] IDs;


    public BaseCharacterControllerConfiguration CurrentCharacterConfigs
    {
        get { return currentCharacterConfigs; }

        set 
        {
            if (currentCharacterConfigs != value)
            {
                currentCharacterConfigs = value;
                onCharacterSwitchedEvent.Invoke(value);
            }
        }
    }

    public BaseInputControllerConfiguration CurrentInputConfigs
    {
        get { return currentInputConfigs; }

        set 
        {
            if (currentInputConfigs != value)
            {
                currentInputConfigs = value;
                onInputSwitchedEvent.Invoke(value);
            }
        }
    }

    public BaseGunControllerConfiguration CurrentWeaponConfigs
    {
        get { return currentWeaponConfigs; }

        set 
        {
            if (currentWeaponConfigs != value)
            {
                currentWeaponConfigs = value;
                onWeaponSwitchedEvent.Invoke(value);
            }
        }
    }

    public void SwitchCharacter(int id)
    {
        var PastCharacterConfigs = currentCharacterConfigs;
        currentCharacterConfigs = IDs[id];
        onCharacterSwitchedEvent.Invoke(currentCharacterConfigs);
        if (PastCharacterConfigs != currentCharacterConfigs) Debug.LogWarning("[-] WARNING: CHARACTER DATA CONTAINER WAS SWITCHED, MAY LEAD TO ISSUES!");
    }
}