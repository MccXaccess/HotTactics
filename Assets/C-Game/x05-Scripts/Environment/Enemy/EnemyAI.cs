using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject[] target;
    NavMeshAgent agent;
    [SerializeField] private float damageAmount = 25f;  // Amount of damage dealt
    [SerializeField] private float rayDistance = 10f;    // Distance of the ray
    [SerializeField] private float cooldownTime = 1f;    // Cooldown time between raycasts
    [SerializeField] private LayerMask layer_mask;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player");

    }
    private void SetTargetPosition()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
    }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector2(target[0].transform.position.x, target[0].transform.position.y));
    }

    private bool canShoot = true;

    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();

        // Check if we can shoot (after cooldown)
        if (canShoot)
        {
            Vector3 directionToTarget = (target[0].transform.position - transform.position).normalized;
            // Cast the ray in the direction of the player (e.g., forward or in a certain angle)
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, rayDistance, layer_mask);

            // If the ray hits something
            if (hit.collider != null)
            {
                // Check if the hit object has the "Player" tag (or your specific player tag)
                if (hit.collider.GetComponent<ModuleHealthPlayer>())
                {
                    // Call the method to deal damage to the player
                    hit.collider.GetComponent<ModuleHealthPlayer>().TakeDamage(damageAmount);

                    // Wait for a second before shooting again
                    StartCoroutine(RayCooldown());
                }
            }
        }
    }

    // Coroutine to handle cooldown
    private IEnumerator RayCooldown()
    {
        canShoot = false; // Disable shooting temporarily
        yield return new WaitForSeconds(cooldownTime); // Wait for the cooldown time
        canShoot = true; // Enable shooting again
    }

    private void OnDrawGizmos()
    {
        // Set Gizmo color (you can change the color to whatever you prefer)
        Gizmos.color = Color.blue;

        Vector3 directionToTarget = (target[0].transform.position - transform.position).normalized;


        // Draw a line from the object's position in the direction it is facing (transform.right) for rayDistance
        Gizmos.DrawRay(transform.position, directionToTarget * rayDistance);
    }
}
