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
    // private Vector3 velocity;

    // [SerializeField] private bool isGrounded;
    // [SerializeField] private float groundCheckDistance;
    // [SerializeField] private LayerMask groundMask;
    // [SerializeField] private float gravity;

    // // References
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
            controller = GetComponent<CharacterController>();
            anim = GetComponentInChildren<Animator>();
    }

    private void Move() {
        Debug.Log("Moves");

        // // Checksphere is going to draw a small sphere which checks if the player stands on the ground.
        // //transform.position = player position, groundcheckdistance = radiance of the sphere, groundmask is layer check if were grounded.
        // isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        // Keyboard input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Place keyboard input X and Z in moveDirection
        moveDirection = new Vector3(moveX, 0, moveZ);

        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
            // Walk
            Walk();

        } else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
            // Run
            Run();
        } else if(moveDirection == Vector3.zero) {
            // Idle
            Idle();
        }

        // Speed up moveDirection
        moveDirection *= moveSpeed;

        // Move
        controller.Move(moveDirection * Time.deltaTime * 2f);

        //Rotate
    }

    private void Update()
    {
        Move();
    }


    // OLD

    private void Idle()
    {
        Debug.Log("Idles");
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        Debug.Log("Walks");
        moveSpeed = walkSpeed;

        // transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (moveDirection), Time.deltaTime * 40f);

        anim.SetFloat("Speed", 0.5f);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        // // 0,1f + Time.deltaTime is going to smoothen the animation
        anim.SetFloat("Speed", 1);
    }
}
