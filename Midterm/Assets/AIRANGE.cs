using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRANGE : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public float chaseRange = 10f;
    public float stoppingDistance = 1f;

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private bool isChasing = false;
    private Vector3 originalPosition;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
        SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseRange)
            {
                isChasing = true;
                SetDestination(player.position);
            }
            else if (isChasing && distanceToPlayer > chaseRange)
            {
                isChasing = false;
                SetDestination(originalPosition);
            }

            if (!isChasing && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                SetNextWaypoint();
            }
        }
    }

    private void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        SetDestination(waypoints[currentWaypointIndex].position);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}