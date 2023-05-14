using System;

[Serializable]
public class BaseCharacterControllerReference
{
    public bool OverrideValue;
    public float value;
    public BaseCharacterControllerConfiguration configs;
    /*/
    public float Value
    {
        get { return OverrideValue ? value : configs.value; }
    }
    /*/
}