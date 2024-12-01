using UnityEngine;

// VERY BAD, DEMODULATION IS SEVERELY LACKING , I CAN'T DO ANYTHING ABOUT IT, SORRY, Z
public class ModuleHealthEnemy : MonoBehaviour
{
    [SerializeField] private BaseEnemyControllerConfiguration enemyConfiguration;
    [SerializeField] private float instanceHealth;

    private void Start()
    {
        if (enemyConfiguration == null)
        {
            DebugOutput.Error("CANT FIND ENEMY CONFIG IN MODULE HEALTH", "unable to locate enemy config");
        }

        instanceHealth = enemyConfiguration.HealthMaximumAmount;
    }

    public void TakeDamage(float damage)
    {
        instanceHealth -= damage;

        if (instanceHealth <= 0)
        {
            Object.Destroy(gameObject);
        }
    }
}