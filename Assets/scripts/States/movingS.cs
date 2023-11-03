using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingS : State
{
    public movingS(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        ps.CheckForIdle();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        ps.MovePLayer();
    }
}
