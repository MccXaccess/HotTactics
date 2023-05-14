using UnityEngine;

public static class ExtensionGetRelativeRotation
{
    public static Vector3 GetRotationFromToCursor(this Transform targetPosition)
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = Camera.main.transform.position.z - targetPosition.position.z;

        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector3 direction = mouseWorldPoint - targetPosition.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        Vector3 adjustedRotation = targetPosition.rotation.eulerAngles;

        return adjustedRotation;
    }
}