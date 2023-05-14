using UnityEngine;

public class ModuleScale : MonoBehaviour
{
    [Tooltip("Given value modifies size of the cursor depending on Camera's Orthographic size")]
    [SerializeField] private float _sizeDivider = 35f;
    private Camera mainCamera = null;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float cameraSize = mainCamera.orthographicSize;
        Vector3 adjustedScale = new Vector3(cameraSize / _sizeDivider, cameraSize / _sizeDivider, cameraSize / _sizeDivider);
        transform.localScale = adjustedScale;
    }
}