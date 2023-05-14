using System;
using System.Reflection;
using UnityEngine;

public static class ExtensionSetPropertyValue
{
    public static void SetPropertyValue(this object obj, string propertyName, object value)
    {
        var property = obj.GetType().GetProperty(propertyName);
        if (property != null && property.CanWrite)
        {
            property.SetValue(obj, value);
            Debug.Log($"Set {propertyName} to {value}");
        }
        else
        {
            Debug.LogWarning($"Failed to set {propertyName} to {value}");
        }
    }
}