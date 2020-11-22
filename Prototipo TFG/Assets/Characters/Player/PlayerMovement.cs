using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed;
    public float jump;
    private float axisX, axisZ;
    private Vector3 direction, moveDirection;
    private float targetAngle, smoothAngle;
    public float turnSmoothTime;
    private float turnSmoothVelocity;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the input value
        axisX = Input.GetAxisRaw("Horizontal");
        axisZ = Input.GetAxisRaw("Vertical");
        //set the direction we want to move to
        direction = new Vector3(axisX, 0, axisZ).normalized;

        if(direction.magnitude >= 0.1f)
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
            controller.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);
        }
    }
}
