using UnityEngine;

public static class ExtensionSetBoolean
{
    public static void SetBoolean(this object characterConfigs, string booleanName, bool state)
    {
        var property = characterConfigs.GetType().GetProperty(booleanName);
        property?.SetValue(characterConfigs, state);
    }
}