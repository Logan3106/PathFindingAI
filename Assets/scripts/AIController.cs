using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform[] target = { };

    private NavMeshAgent agent;
    private int destPoint;


    void Start()
    { 
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if(target.Length == 0)
        {
            return;
        }

        agent.destination = target[destPoint].position;
        destPoint = (destPoint + 1) % target.Length;
    }
}
