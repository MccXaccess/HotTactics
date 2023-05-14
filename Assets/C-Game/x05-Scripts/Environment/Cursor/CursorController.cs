using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{    
    [SerializeField] private Transform cursorTransform;
    [SerializeField] private Transform playerTransfrom;

    [SerializeField] private Vector3 velocity = Vector3.zero;

    [SerializeField] private float _smoothTime = 0.1f;

    [SerializeField] private bool _orthographic = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    // NOTE : orthographic or not should be choosen in camera controller script not directly in this script.
    // NOTE : zooming in/out should be adaptet to both types of cameras 'orthographic' && 'perspective'

    private void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector2 outputMousePosition = _orthographic ? GetOrthographic(mousePosition) : GetPerspective(mousePosition, 0);

        Vector3 targetPosition = cursorTransform.TransformPoint(new Vector3(0, 0, 0));

        cursorTransform.position = Vector3.SmoothDamp(targetPosition, outputMousePosition, ref velocity, _smoothTime);
        
        cursorTransform.rotation = playerTransfrom.rotation;
    }

    public Vector3 GetPerspective(Vector3 screenPosition, float z)
    {
        Camera.main.orthographic = _orthographic;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        Vector3 hitPoint = ray.GetPoint(distance);

        return hitPoint;
    }

    public Vector3 GetOrthographic(Vector3 screenPosition)
    {
        Camera.main.orthographic = _orthographic;
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
}