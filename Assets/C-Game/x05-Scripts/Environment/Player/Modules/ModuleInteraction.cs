using UnityEngine;
using System.Collections;

public class ModuleInteraction : MonoBehaviour
{
    private Collider2D _savedCollider; 
    private Vector3 _positionOffset;

    public void PickUp(ref GameObject currentWeapon, GameObject activeField, Collider2D collision, Vector3 offsetPosition)
    {
        currentWeapon = collision.gameObject;

        currentWeapon.transform.parent = activeField.transform;

        _positionOffset = offsetPosition;

        currentWeapon.transform.localPosition = _positionOffset;

        currentWeapon.transform.rotation = new Quaternion(0,0,0,0);

        TurnCollider(ref collision, false);
    }

    public void Drop(ref GameObject currentWeapon, ref GameObject activeField, Collider2D collision)
    {
        Transform parentTransform = activeField.transform;

        Transform firstChildTransform = parentTransform.GetChild(0);

        parentTransform.DetachChildren();

        firstChildTransform = null;

        //StartCoroutine(DroppedWeapon(currentWeapon));

        TurnCollider(ref _savedCollider, true);

        currentWeapon = null;
    }

    private void TurnCollider(ref Collider2D collider, bool value)
    {
        _savedCollider = collider;
        //collider.enabled = !collider.enabled;
        collider.enabled = value;
    }

    private IEnumerator DroppedWeapon(GameObject currentWeapon, float duration = 1.5f)
    {
        Vector3 startPosition = currentWeapon.transform.position;
        Vector3 targetPosition = startPosition + transform.up * 5f;

        Quaternion startRotation = currentWeapon.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 360f);

        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float elapsed = Time.time - startTime;
            float t = elapsed / duration;

            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t * 2);
            Quaternion newRotation = Quaternion.Lerp(startRotation, targetRotation, t);

            currentWeapon.transform.position = newPosition;
            currentWeapon.transform.rotation = newRotation;

            yield return null;
        }
    }
}