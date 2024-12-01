using UnityEngine;

// VERY BAD, DEMODULATION IS SEVERELY LACKING , I CAN'T DO ANYTHING ABOUT IT, SORRY, Z
public class ModuleHealthPlayer : MonoBehaviour
{
    [SerializeField] private BaseCharacterControllerConfiguration characterConfiguration;
    [SerializeField] private CameraController cameraController;

    private void Start()
    {
        characterConfiguration.HealthCurrentAmount = characterConfiguration.HealthMaximumAmount;
    }
    public void TakeDamage(float damage)
    {
        characterConfiguration.HealthCurrentAmount -= damage;
        cameraController.Shake(0.2f, 1f);

        if (characterConfiguration.HealthCurrentAmount <= 0)
        {
            transform.position = Vector3.zero;
            characterConfiguration.HealthCurrentAmount = characterConfiguration.HealthMaximumAmount;
        }
    }
}