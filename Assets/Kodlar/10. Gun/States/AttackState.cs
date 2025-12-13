using UnityEngine;

class AttackState : IState
{
    private BasicAIController _controller;

    public AttackState(BasicAIController controller)
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
            _controller.player.position) > 2)
        {
            _controller.ChangeState(AIState.Chase);
        }
    }
}