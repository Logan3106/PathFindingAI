using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    private float _verticalInput;
    private float _horizontalInput;
    public Moving(MovementSM stateMachine) : base("moving", stateMachine) { }
    public override void Enter()
    {
        base.Enter();
        _verticalInput = 0f;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
