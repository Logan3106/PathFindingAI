using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemy : State
{
    public IdleEnemy(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
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

        gs.CheckForHunt();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
