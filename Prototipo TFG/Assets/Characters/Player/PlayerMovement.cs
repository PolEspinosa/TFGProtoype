using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed, windSpeedMult, pushSpeed;
    private float windSpeed, currentSpeed;
    private bool windActive; //wind spirit invoked
    private bool earthActive; //earth spirit invoked
    public float jumpHeight;
    private float axisX, axisZ;
    private Vector3 direction, moveDirection;
    private float targetAngle, smoothAngle;
    public float turnSmoothTime;
    private float turnSmoothVelocity;
    public Transform cam;
    public float gravity;
    private float yStore;
    public GameObject currentSpirit;
    private bool pushing;
    private GameObject movingObject; //object the player is currently moving
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
        windSpeed = walkSpeed * windSpeedMult;
        movingObject = null;
        pushSpeed = walkSpeed * 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpirit != null)
        {
            if (currentSpirit.CompareTag("EarthSpirit"))
            {
                earthActive = true;
                windActive = false;
            }
            else if (currentSpirit.CompareTag("WindSpirit"))
            {
                windActive = true;
                earthActive = false;
            }
            //if neither the earth spirit nor the wind spirits are invoked
            else
            {
                earthActive = false;
                windActive = false;
            }
        }
        //if no spirits invoked
        else
        {
            earthActive = false;
            windActive = false;
        }

        if (windActive)
        {
            currentSpeed = windSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        //get the input value
        axisX = Input.GetAxisRaw("Horizontal");
        axisZ = Input.GetAxisRaw("Vertical");
        //store the y value before normalizing it
        yStore = moveDirection.y;
        //set the direction we want to move to
        direction = new Vector3(axisX, 0, axisZ).normalized;


        if (direction.magnitude >= 0.1f)
        {
            //don't apply rotation if the player is moving a box
            if (!pushing)
            {
                //find the angle the player needs to rotate in order to face the direction is moving to
                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                //smooth the angle 
                smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                //apply the rotation
                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
                //set the direction to the one the camera is facing
                moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //move the player
                //controller.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);
            }
            else
            {
                //move backwards with the box
                if (axisZ < 0)
                {
                    moveDirection = -gameObject.transform.forward;
                }
                //move forward with the box
                else if(axisZ > 0)
                {
                    moveDirection = gameObject.transform.forward;
                }
                //move right with the box
                else if(axisX > 0)
                {
                    moveDirection = gameObject.transform.right;
                }
                //move left with the box
                else if (axisX < 0)
                {
                    moveDirection = -gameObject.transform.right;
                }
            }
        }
        //if there is no movement input, stop moving
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
        }

        //use the not normalized Y value for the jump
        moveDirection.y = yStore;

        //if the player is on the ground
        if (controller.isGrounded)
        {
            //don't apply gravity
            moveDirection.y = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpHeight;
            }
        }
        //apply gravity
        moveDirection.y += (Physics.gravity.y * gravity * Time.deltaTime);
        //move the player
        controller.Move(moveDirection * Time.deltaTime * currentSpeed);
        
        
    }


    private void OnTriggerStay(Collider other)
    {
        //if in range of a box and using right input
        if(other.CompareTag("Box") && earthActive && Input.GetKey(KeyCode.E))
        {
            pushing = true;
            currentSpeed = pushSpeed;
            movingObject = other.gameObject;
            movingObject.transform.parent = gameObject.transform;
        }
        else
        {
            pushing = false;
            movingObject.transform.parent = null;
            movingObject = null;
            
        }
    }
}
