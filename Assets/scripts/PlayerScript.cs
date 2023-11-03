using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 3;

    public Rigidbody rb;

    public Vector3 move;

    public IdleSM idleS;

    public movingS ms;

    public StateMachine sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = gameObject.GetComponent<StateMachine>();
        rb = gameObject.GetComponent<Rigidbody>();

        idleS = new IdleSM(this, sm);
        ms = new movingS(this, sm);

        sm.Init(idleS);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        sm.CurrentState.HandleInput();
        sm.CurrentState.LogicUpdate();

    }

    void FixedUpdate()
    {
        sm.CurrentState.PhysicsUpdate();

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }


    public void PlayerInput()
    {
        //Gets the horizontal input to be used for the 
        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");
    }

    //If movement input, current = moving
    public void CheckForMoveInput()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            sm.ChangeState(ms);
        }
    }

    //If no input then state = idle
    public void CheckForIdle()
    {
        if (!Input.anyKey)
        {
            if (rb.velocity.magnitude <= 0.2)
            {
                sm.ChangeState(idleS);
            }
        }
    }

    //Used by the Moving state to make the player move
    public void MovePLayer()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}
