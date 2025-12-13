using UnityEngine;

class PatrolState : IState
{
    private BasicAIController _controller;
    private Transform currentPatrolTarget;
    private int currentPatrolIndex=0;

    public PatrolState(BasicAIController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {
        // currentPatrolTarget = _controller
        // .patrolPoints[Random.Range(0, _controller.patrolPoints.Count)];
    }

    public void Exit()
    {
        currentPatrolIndex += 1;
        currentPatrolIndex =
        currentPatrolIndex % _controller.patrolPoints.Count;
    }

    public void Update()
    {
        if (Vector3.Distance(
            _controller.gameObject.transform.position,
            _controller.player.position) < 10)
        {
            _controller.ChangeState(AIState.Chase);
        }

        Vector3.MoveTowards(
            _controller.gameObject.transform.position,
            _controller.patrolPoints[currentPatrolIndex].position,
            _controller.speed * Time.deltaTime);

        if (Vector3.Distance(
            _controller.gameObject.transform.position,
            currentPatrolTarget.position) < .5f)
        {
            _controller.ChangeState(AIState.Idle);
        }


    }
}