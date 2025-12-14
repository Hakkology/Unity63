using UnityEngine;

class MovingState : IState
{
    private BasicAIController _controller;

    public MovingState(BasicAIController controller)
    {
        _controller = controller;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (Vector3.Distance(
            _controller.gameObject.transform.position,
            _controller.player.position) > 10)
        {
            _controller.ChangeState(AIState.Idle);
        }

        if (Vector3.Distance(
            _controller.gameObject.transform.position,
            _controller.player.position) < 2)
        {
            _controller.ChangeState(AIState.Attack);
        }

        // Vector3.MoveTowards(
        //     _controller.gameObject.transform.position,
        //     _controller.player.position,
        //     _controller.speed * Time.deltaTime);

        _controller.agent.SetDestination(_controller.player.position);
    }
}