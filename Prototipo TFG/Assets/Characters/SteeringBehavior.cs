using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    public float followSpeed;
    public float slowdownDistance;

    private Vector3 velocity;
    private Vector3 targetDistance;
    private Vector3 desiredVelocity;
    private Vector3 steering;
    private float slowdownFactor;
    private GameObject player;
    private Vector3 target;
    private bool aiming;
    private Ray ray;
    private RaycastHit hit;
    private enum State { FOLLOWING, GOING};
    private State state;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        player = GameObject.FindGameObjectWithTag("Player");
        state = State.FOLLOWING;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        Orders();
        //direction in which the character has to move
        targetDistance = (target - gameObject.transform.position);
        //the desired velocity the character needs in order to go to he target
        desiredVelocity = targetDistance.normalized * followSpeed;
        //the force needed in order to move to the target
        steering = desiredVelocity - velocity;
        //update current velocity
        velocity += steering;
        //Calculate slowdown factor
        slowdownFactor = Mathf.Clamp01(targetDistance.magnitude / slowdownDistance);
        velocity *= slowdownFactor;
        //update current position
        transform.position += velocity * Time.deltaTime;
    }

    private void Orders()
    {
        //aim
        if (Input.GetMouseButtonDown(1))
        {
            aiming = true;
        }
        //stop aiming
        else if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
        }
        if(aiming && Input.GetMouseButtonDown(0))
        {
            state = State.GOING;
        }
        //make the spirit follow
        else if (!aiming && Input.GetMouseButtonDown(0))
        {
            state = State.FOLLOWING;
        }

        switch (state)
        {
            case State.FOLLOWING:
                target = player.transform.position;
                break;
            case State.GOING:
                target= player.GetComponent<ControlSpirits>().hit.point;
                break;
            default:
                break;
        }
    }
}
