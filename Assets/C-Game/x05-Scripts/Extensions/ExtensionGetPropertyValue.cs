using UnityEngine;

public static class ExtensionGetPropertyValue 
{
    public static object GetPropertyValue(this object obj, string propertyName)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        if (propertyInfo != null)
        {
            return propertyInfo.GetValue(obj);
        }
        else
        {
            return null;
            Debug.LogError($"Property {propertyName} not found on object {obj}");
        }
    }
}