using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicPlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> patrolPoints;
    public int currentPatrolIndex;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentPatrolIndex = 0;
    }

    void Update()
    {
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        if (agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = Random.Range(0, patrolPoints.Count);
        }
    }
}