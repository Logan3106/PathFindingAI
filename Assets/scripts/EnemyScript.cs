using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript ps;

    public GameObject spawn;
    public GameObject[] targets = { };

    public int destPoint;

    public NavMeshAgent agent;

    public Animator anim;

    public bool dead;

    public float idleDuration;
    public bool canHunt = false;

    //Player status variables
     IdleEnemy gidleS;
     Hunting huntingS;

    private StateMachine sm;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sm = gameObject.AddComponent<StateMachine>();
        anim = GetComponent<Animator>();

        // add new states here
        gidleS = new IdleEnemy(this, sm);
        huntingS = new Hunting(this, sm);


        // initialise the statemachine with the default state
        sm.Init(gidleS);

        StartCoroutine(BeginHunt());

    }

    // Update is called once per frame
    void Update()
    {
        sm.CurrentState.HandleInput();
        sm.CurrentState.LogicUpdate();
        //print(sm.CurrentState);
    }

    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5F && canHunt)
        {
            GoToTarget();
        }

    }

    public void GoToTarget()
    {
        if (targets.Length == 0)
        {
            print("No targets");
            return;
        }

        agent.destination = targets[destPoint].transform.position;
        destPoint = (destPoint + 1) % targets.Length;
    }

    public void CheckForHunt()
    {
        if (canHunt)
        {
            sm.ChangeState(huntingS);
        }
        else
        {
            sm.ChangeState(gidleS);
        }
    }

    public IEnumerator BeginHunt()
    {
        yield return new WaitForSeconds(idleDuration);

        canHunt = true;
    }

}
