using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleEnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnpoints = new List<Transform>(); // List of spawn points
    [SerializeField] private int maxEntityAmount = 30; // Max number of enemies to instantiate
    [SerializeField] private List<GameObject> entitiesVaritation = new List<GameObject>(); // List of enemy variations
    private List<GameObject> instantiatedEntities = new List<GameObject>(); // Keep track of instantiated enemies

    private void Update()
    {
        // Instantiate enemies if the current count is less than the max amount
        if (instantiatedEntities.Count < maxEntityAmount)
        {
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {
        // Pick a random enemy variation from the list
        GameObject randomEnemy = entitiesVaritation[UnityEngine.Random.Range(0, entitiesVaritation.Count)];

        // Pick a random spawn point from the list of spawn points
        Transform randomSpawnPoint = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Count)];

        // Instantiate the random enemy at the chosen spawn point position
        GameObject spawnedEnemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

        // Optionally, you can adjust rotation here if needed
        // For example, you can rotate the enemy based on some logic like facing the player:
        // spawnedEnemy.transform.rotation = Quaternion.LookRotation(someDirection);

        // Add the instantiated enemy to the list
        instantiatedEntities.Add(spawnedEnemy);
    }
}
