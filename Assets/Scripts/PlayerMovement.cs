using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // // Variables
    // [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    // [SerializeField] private float gravity;

    // // References
    private CharacterController charController;
    private Animator animator;

    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private Vector3 v_velocity;

    private float moveSpeed;
    private float gravity;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        moveSpeed = 4f;
        gravity = 0.5f;
    }

    // private void Move() {
    //     // // Checksphere is going to draw a small sphere which checks if the player stands on the ground.
    //     // //transform.position = player position, groundcheckdistance = radiance of the sphere, groundmask is layer check if were grounded.
    //     // isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

    //     // Keyboard input
    //     inputX = Input.GetAxis("Horizontal");
    //     inputZ = Input.GetAxis("Vertical");

    //     // // Place keyboard input X and Z in moveDirection
    //     // moveDirection = new Vector3(inputX, 0, inputZ);

    //     // if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
    //     //     // Walk
    //     //     Walk();

    //     // } else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
    //     //     // Run
    //     //     Run();
    //     // } else if(moveDirection == Vector3.zero) {
    //     //     // Idle
    //     //     Idle();
    //     // }

    //     // // Speed up moveDirection
    //     // moveDirection *= moveSpeed;

    //     // // Move
    //     // charController.Move(moveDirection * Time.deltaTime * 2f);

    // }

    private void Update()
    {
        // Move();
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        // input forward
        v_movement = charController.transform.forward * inputZ;

        // char rotate
        // WORKS
        charController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        //char move
        charController.Move(v_movement * moveSpeed * Time.deltaTime);
    }

    // OLD

    // private void Idle()
    // {
    //     Debug.Log("Idles");
    //     animator.SetFloat("Speed", 0);
    // }

    // private void Walk()
    // {
    //     Debug.Log("Walks");
    //     moveSpeed = walkSpeed;

    //     // transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (moveDirection), Time.deltaTime * 40f);

    //     animator.SetFloat("Speed", 0.5f);
    // }

    // private void Run()
    // {
    //     moveSpeed = runSpeed;
    //     // // 0,1f + Time.deltaTime is going to smoothen the animation
    //     animator.SetFloat("Speed", 1);
    // }
}
