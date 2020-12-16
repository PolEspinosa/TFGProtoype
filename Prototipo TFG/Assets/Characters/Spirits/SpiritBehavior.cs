using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiritBehavior : MonoBehaviour
{
    public NavMeshAgent navAgent;
    protected GameObject player;
    protected Vector3 target;
    public enum States { FOLLOWING, GOING, WAITING}; //Follow the player/Go to where the player has said
    public States state;
    public float walkSpeed, runSpeed;
    public float stopDistance = 2f;
    private bool waiting; //bool that will allow the spirit to leave the waiting state
    //reference to the players script
    private ControlSpirits controlSpirits;
    public GameObject targetObject; //we will store the gameobject that has collided with the raycast
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void InitialiseValues()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        state = States.FOLLOWING;
        controlSpirits = player.GetComponent<ControlSpirits>();
        targetObject = null;
        waiting = false;
    }

    protected void FollowOrder()
    {
        //if close enough to the target, wait
        if (navAgent.remainingDistance <= navAgent.stoppingDistance && !waiting)
        {
            state = States.WAITING;
        }
        else
        {
            navAgent.speed = walkSpeed;
        }
        switch (state)
        {
            case States.FOLLOWING:
                navAgent.speed = walkSpeed;
                navAgent.SetDestination(player.transform.position);
                waiting = false;
                navAgent.isStopped = false;
                break;
            case States.GOING:
                navAgent.speed = runSpeed;
                navAgent.SetDestination(controlSpirits.goToPosition);
                waiting = false;
                navAgent.isStopped = false;
                break;
            case States.WAITING:
                navAgent.isStopped = true;
                waiting = true;
                break;
        }
    }

    public void GoTo()
    {
        state = States.GOING;
    }

    public void Follow()
    {
        state = States.FOLLOWING;
        targetObject = null;
    }
}
