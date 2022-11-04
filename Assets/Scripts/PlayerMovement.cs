using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // // Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;

    // // References
    private CharacterController charController;
    private Animator animator;

    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private Vector3 v_velocity;

    private Vector3 moveDirection;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Move() {
        // // Checksphere is going to draw a small sphere which checks if the player stands on the ground.
        // //transform.position = player position, groundcheckdistance = radiance of the sphere, groundmask is layer check if were grounded.
        // isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        // Keyboard input
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        // Place keyboard input X and Z in moveDirection
        moveDirection = new Vector3(inputX, 0, inputZ);
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate() {
        // FixedUpdate should be used instead of update when dealing with RigidBody

        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
            Walk();
        } else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
            // Run
            Run();
        }
        else if(moveDirection == Vector3.zero) {
            // Idle
            Idle();
        }

        // WORKS
        charController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        //char move
        charController.Move(v_movement * moveSpeed * Time.deltaTime);
    }

    private void Idle()
    {
        Debug.Log("Idles");
        animator.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        if(inputX > -1 && inputX < 0) {
            Debug.Log("Turns left");

        } else if(inputX > 0 && inputX < 1) {
            Debug.Log("Turns Right");

        }
        else {
            animator.SetFloat("Speed", 0.5f);
        }

        v_movement = charController.transform.forward * inputZ;

        Debug.Log("Walks");
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        // // 0,1f + Time.deltaTime is going to smoothen the animation
        animator.SetFloat("Speed", 1);
    }
}
