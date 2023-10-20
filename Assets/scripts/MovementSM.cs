using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public IdleSM idleState;
    [HideInInspector]
    public Moving movingState;

    public Rigidbody rb;
    public float dirX, dirY;
    public float speed;
    public void Awake()
    {
        idleState = new IdleSM(this);
        movingState = new Moving(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public void Update()
    {
         dirX = Input.GetAxis("Horizontal") * speed;
        dirY = Input.GetAxis("Vertical") * speed;
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirY);
    }
}
