using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Data Container:")]
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;

    [Header("Target:")]
    [SerializeField] private Transform _cursorTarget;

    [Header("Base Options:")]
    [SerializeField] private float _maxLookoutDistance = 3f;
    [SerializeField] private float _followSpeed = 3f;

    // Переменные для тряски камеры
    public bool isShaking = false;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.4f;
    private float dampingSpeed = 1.0f;

    private Vector3 _cursorVelocity = Vector3.zero;
    private GameObject _playerObject;


    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        EventHandler.onCharacterSwitchedEvent.AddListener(OnValueChanged);
    }

    private void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        Vector3 playerPosition = new Vector3(_playerObject.transform.position.x, _playerObject.transform.position.y, -10f);

        // Calculate the difference between the camera position and the target position
        Vector3 offset = playerPosition - transform.position;

        // Get the direction to the cursor
        Vector3 cursorDirection = _cursorTarget.position;

        // Clamp the distance to the maximum
        float distance = Mathf.Clamp(cursorDirection.magnitude, 1f, _maxLookoutDistance);

        // Normalize the direction
        cursorDirection.Normalize();

        // Move the target position based on the cursor direction and the clamped distance
        transform.position = _cursorTarget.position - cursorDirection * distance;

        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                // Генерация случайного смещения внутри сферы
                Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
                shakeOffset.z = 0; // Избегаем смещения по оси Z
                transform.position += shakeOffset;

                shakeDuration -= Time.fixedDeltaTime * dampingSpeed;
            }
            else
            {
                isShaking = false;
            }
        }

        // Lerp the camera position to the target position
        transform.position = Vector3.Lerp(playerPosition, transform.position + offset, Time.fixedDeltaTime * _followSpeed);
    }

    // BY ARTEMIY THE FORGOTTEN ONE
    /// <summary>
    /// Метод для запуска тряски камеры.
    /// </summary>
    /// <param name="duration">Длительность тряски в секундах.</param>
    /// <param name="magnitude">Интенсивность тряски.</param>
    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        isShaking = true;
    }

    private void OnValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }
}