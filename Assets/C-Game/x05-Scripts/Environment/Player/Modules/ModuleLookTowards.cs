using UnityEngine;

public class ModuleLookTowards : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;
    private GameObject rootParentObject;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
        rootParentObject = transform.root.gameObject;
    }

    private void Update()
    {
        LookTowardsMouse(rootParentObject.transform);
    }

    public void LookTowardsMouse(Transform target)
    {
        Vector3 ObjPos = Camera.main.WorldToScreenPoint(target.position);

        Vector3 dir = Input.mousePosition - ObjPos;

        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        characterConfigs.RB2D.MoveRotation(-rotZ);
    }

    public void LookTowardsDirection(Vector3 lookDirection)
    {
        // FINISH this method.
    }

    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }
}