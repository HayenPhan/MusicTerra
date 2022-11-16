using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    private Animator animator;
    private CharacterController charController;

    // Script is added to Player prefab
    // Other components
    // NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;

    // private float gravity = 3f;

    NetworkCharacterControllerPrototype networkCharacterControllerPrototype;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 v_movement;


    private void Awake()
    {
        networkCharacterControllerPrototype = GetComponent<NetworkCharacterControllerPrototype>();
        // Fetch network character controller
        charController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void FixedUpdateNetwork()
    {
        //Get the input from the network
            if(GetInput(out NetworkInputData networkInputData))
            {
                // networkCharacterControllerPrototype.Rotate(networkInputData.rotationInput);
                if(networkInputData.movementInput != Vector2.zero && !Input.GetKey(KeyCode.LeftShift)) {
                    animator.SetFloat("Speed", 0.5f);
                    moveSpeed = walkSpeed;
                } else if(networkInputData.movementInput != Vector2.zero && Input.GetKey(KeyCode.LeftShift)) {
                    // Run
                    moveSpeed = runSpeed;
                    animator.SetFloat("Speed", 1);
                }
                else if(networkInputData.movementInput == Vector2.zero) {
                    // Idle
                    animator.SetFloat("Speed", 0);
                }

                //Move
                // Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;

                Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;

                moveDirection.Normalize();

                networkCharacterControllerPrototype.Move(moveDirection, moveSpeed);

                // // This works but character floats above ground
                // //  networkInputData.movementInput *= moveSpeed;
                // // charController.Move(networkInputData.movementInput);
                // if(charController.isGrounded)
                // {
                //     Debug.Log("Character is grounded!");
                //     networkInputData.movementInput *= moveSpeed;
                // }

                // // Use this to ground the character

                // charController.Move(networkInputData.movementInput * Time.deltaTime);
            }
    }
}
