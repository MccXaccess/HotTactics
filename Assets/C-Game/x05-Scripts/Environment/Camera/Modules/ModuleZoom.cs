using UnityEngine;

public class ModuleZoom : MonoBehaviour
{
    [Header("Zoom Speed:")]
    [SerializeField] private float _zoomSpeeed = 1f;
    [SerializeField] private float _smoothSpeed = 5f;
    [Space(10)]
    [Header("Zoom Distance:")]
    [SerializeField] private float _minZoomDistance = 1f;
    [SerializeField] private float _maxZoomDistance = 20f;
    
    private float _targetCurrentZoom;

    void Start()
    {
        _targetCurrentZoom = Camera.main.orthographicSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        _targetCurrentZoom -= scroll * _zoomSpeeed;
        _targetCurrentZoom = Mathf.Clamp(_targetCurrentZoom, _minZoomDistance, _maxZoomDistance);

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, _targetCurrentZoom, _smoothSpeed * Time.deltaTime);
    }
}