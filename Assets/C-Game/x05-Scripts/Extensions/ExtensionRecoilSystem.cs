using UnityEngine;

public static class ExtensionRecoilSystem
{
    public static void RecoilSystem(this BaseCharacterControllerConfiguration characterConfigs, string recoilClampName, float value)
    {
        var property = characterConfigs.GetType().GetProperty(recoilClampName);

        float maximumClamp = (float)property.GetValue(characterConfigs);

        if (maximumClamp+0.1f < characterConfigs.RecoilCurrent) { characterConfigs.RecoilCurrent -= value; }
        else if (maximumClamp > characterConfigs.RecoilCurrent) { characterConfigs.RecoilCurrent += value; }
    }
}