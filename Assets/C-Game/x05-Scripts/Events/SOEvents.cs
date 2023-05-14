using UnityEngine.Events;

public class SOEvents
{
    public class OnCharacterSwitched : UnityEvent<BaseCharacterControllerConfiguration> { }
    public class OnInputSwitched : UnityEvent<BaseInputControllerConfiguration> { }
    public class OnWeaponSwitched : UnityEvent<BaseGunControllerConfiguration> { }
}