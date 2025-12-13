using System;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Idle,
    Chase,
    Attack,
    Patrol
}

public class BasicAIController : MonoBehaviour
{
    public Transform player;
    public List<Transform> patrolPoints;
    public float speed = 4;

    private IState idleState;
    private IState movingState;
    private IState attackState;
    private IState patrolState;
    private IState currentState;

    private void Start()
    {
        idleState = new IdleState(this);
        movingState = new MovingState(this);
        idleState = new AttackState(this);
        patrolState = new PatrolState(this);

        currentState = idleState;
    }

    void Update()
    {
        currentState.Update();
    }


    public void ChangeState(AIState newState)
    {
        currentState.Exit();
        SwitchState(newState);
        currentState.Enter();
        Debug.Log("State Change: " + newState.ToString());
    }

    private void SwitchState(AIState state)
    {
        switch (state)
        {
            case AIState.Idle:
                currentState = idleState;
                break;
            case AIState.Chase:
                currentState = movingState;
                break;
            case AIState.Attack:
                currentState = attackState;
                break;
            case AIState.Patrol:
                currentState = patrolState;
                break;
        }
    }
}