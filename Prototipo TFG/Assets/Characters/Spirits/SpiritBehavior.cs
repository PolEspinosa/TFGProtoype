using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiritBehavior : MonoBehaviour
{
    public NavMeshAgent navAgent;
    protected GameObject player;
    private Vector3 target;
    public enum States { FOLLOWING, GOING}; //Follow the player/Go to where the player has said
    public States state;
    public float walkSpeed, runSpeed;
    public float stopDistance = 2f;
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
    }

    protected void FollowOrder()
    {
        //if close enough to the target, wait
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            
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
                break;
            case States.GOING:
                navAgent.speed = runSpeed;
                navAgent.SetDestination(controlSpirits.goToPosition);
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
