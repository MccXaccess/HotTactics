using UnityEngine;

public class BaseMovementController : MonoBehaviour
{
    public float movementSpeed = 5f;

    public KeyCode movementForward = KeyCode.W;
    public KeyCode movementBackward = KeyCode.S;
    public KeyCode movementLeft = KeyCode.A;
    public KeyCode movementRight = KeyCode.D;

    Quaternion currentRotation;

    Vector3 currentEulerAngles;

    public KeyCode ms = KeyCode.LeftAlt;

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    private Rigidbody2D _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Horizontal");
        float v = verticalSpeed * Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector2(h * movementSpeed, v * movementSpeed);

        Vector3 ObjPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 dir = Input.mousePosition - ObjPos;

        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        _rigidbody.MoveRotation(-rotZ);
    }
}