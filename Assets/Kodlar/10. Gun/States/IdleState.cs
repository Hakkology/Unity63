using UnityEngine;

class IdleState : IState
{
    private BasicAIController _controller;
    private float timer = 0;

    public IdleState(BasicAIController controller)
    {
        _controller = controller;
    }
    
    public void Enter()
    {

    }

    public void Exit()
    {
        // timer = 0;
    }

    public void Update()
    {
        if (Vector3.Distance(
            _controller.gameObject.transform.position,
            _controller.player.position) < 10)
        {
            _controller.ChangeState(AIState.Chase);
        }

        timer += Time.deltaTime;
        if (timer > 4)
        {
            timer = 0;
            _controller.ChangeState(AIState.Patrol);
        }
    }
}