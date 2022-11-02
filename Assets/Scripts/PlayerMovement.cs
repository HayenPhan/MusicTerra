using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // // Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    // // References
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
            controller = GetComponent<CharacterController>();
            anim = GetComponentInChildren<Animator>();
    }

    private void Move() {

        // Checksphere is going to draw a small sphere which
        //transform.position = player position, groundcheckdistance = radiance of the sphere, groundmask is layer check if were grounded.
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        // This stops applying gravity when we are grounded
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        // moveDirection = transform.TransformDirection(moveDirection);

        if(isGrounded) {
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
                // Walk
                Walk();

            } else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
                // Run
                // Run();
            } else if(moveDirection == Vector3.zero) {
                // Idle
                Idle();
            }

            moveDirection *= moveSpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // float moveX = Input.GetAxis("Horizontal");

        // x, y, z <-- used this code first
        //moveDirection = new Vector3(moveX, 0, moveZ);

        // x, y, z <-- Add camera main forward and right to move character in the direction of the camera.
        // If you don't do this, your character will move the opposite direction, because it doesn't know the position of the camera.
        // moveDirection = Camera.main.transform.forward * moveZ + Camera.main.transform.right * moveX;

        // // Makes the player move in the right directions even when rotating with mouse
        // // moveDirection = transform.TransformDirection(moveDirection);

        // // If walkspeed is 5, moveZ will be multiplied by 5. So it walks 5 times faste
        // // moveDirection *= walkSpeed;

        // // // If our movement is not equal to 0, 0, 0 then..
        // // if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        // // {
        // //     // Walk
        // //     Walk();
        // // }
        // // else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
        // //     Run();
        // // }
        // // else if(moveDirection == Vector3.zero)
        // // {
        // //     // Idle
        // //     Idle();
        // // }

        // if(moveDirection == Vector3.zero) {
        //     // Idle
        //     Idle();
        // } else if(!Input.GetKey(KeyCode.LeftShift)) {
        //     // Walk
        //     Walk();
        // } else {
        //     // Rum
        // }

        // // // Multiply direction with wanted speed
        // moveDirection *= moveSpeed;

        // // Time.delta -> doesn't matter how many frames you have, you will still move the same amount of time.
        // controller.Move(moveDirection * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        // // Missing code
        anim.SetFloat("Speed", 0.8f, 01f, Time.deltaTime);
        // anim.SetFloat("Speed", 0.5f);
    }

    // private void Run()
    // {
    //     moveSpeed = runSpeed;
    //     // // 0,1f + Time.deltaTime is going to smoothen the animation
    //     anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    // }
}
