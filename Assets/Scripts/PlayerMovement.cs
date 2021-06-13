using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;

    // References
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Camera.main != null) {
        Move();
        }
    }

    private void Move()
    {
        // Forward en Backwards
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        // x, y, z <-- used this code first
        //moveDirection = new Vector3(moveX, 0, moveZ);

        // x, y, z <-- Add camera main forward and right to move character in the direction of the camera.
        // If you don't do this, your character will move the opposite direction, because it doesn't know the position of the camera.
            moveDirection = Camera.main.transform.forward * moveZ + Camera.main.transform.right * moveX;

            // Makes the player move in the right directions even when rotating with mouse
            // moveDirection = transform.TransformDirection(moveDirection);

            // If walkspeed is 5, moveZ will be multiplied by 5. So it walks 5 times faste
            // moveDirection *= walkSpeed;

            // If our movement is not equal to 0, 0, 0 then..
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                // Walk
                Walk();
            }
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
                Run();
            }
            else if(moveDirection == Vector3.zero)
            {
                // Idle
                Idle();
            }

            // // Multiply direction with wanted speed
            moveDirection *= moveSpeed;


            // Time.delta -> doesn't matter how many frames you have, you will still move the same amount of time.
            controller.Move(moveDirection * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        // Missing code
        anim.SetFloat("Speed", 0.8f, 01f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        // 0,1f + Time.deltaTime is going to smoothen the animation
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

}
