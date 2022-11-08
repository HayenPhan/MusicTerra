using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    private float walkSpeed;
    private float moveSpeed;
    private float runSpeed;

    private Vector3 v_movement;
    private Vector3 v_velocity;
    private Vector3 moveDirection;

    private Animator animator;

    // Script is added to Player prefab
    // Other components
    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;

    private void Awake()
    {
        // Fetch network character controller
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 0;
        moveSpeed = 5;
        runSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // We need a fixed update so it will work over the network
    // The normal update function will only be triggered locally, it has nothing to do with the network so it's impossible to use that function to move the character
    // use FixedUpdateNetwork() instead

    public override void FixedUpdateNetwork()
    {
        // Get network input data to move the character
        // The clients are sending their inputs to the server and the server is authorative and decides waht is going on
        // At the end the server is going to move things and it's on the server that the physical simulation is happening
        // For it to really work the input from the client is needed

        // Place keyboard input X and Z in moveDirection

        //Get the input from the network
        if(GetInput(out NetworkInputData networkInputData))
        {
            // Place keyboard input X and Z in moveDirection
            moveDirection = new Vector3(networkInputData.movementInput.x, 0, networkInputData.movementInput.z);

            // Z = Y because Vector2 is used in CharacterInputHandler
            // moveDirection = new Vector3(networkInputData.movementInput.x, 0, networkInputData.movementInput.y);

                if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
                    // WALK
                    // Walk();
                     if(networkInputData.movementInput.x > -1 && networkInputData.movementInput.x < 0) {
                        Debug.Log("Turns left");

                        } else if(networkInputData.movementInput.x > 0 && networkInputData.movementInput.x < 1) {
                            Debug.Log("Turns Right");

                        }
                        else {
                            animator.SetFloat("Speed", 0.5f);
                        }

                        v_movement = networkCharacterControllerPrototypeCustom.transform.forward * networkInputData.movementInput.z;

                        Debug.Log("Walks");
                        moveSpeed = walkSpeed;
                } else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
                    // Run
                    // Run();
                    moveSpeed = runSpeed;
                    // // 0,1f + Time.deltaTime is going to smoothen the animation
                    animator.SetFloat("Speed", 1);
                }
            else if(moveDirection == Vector3.zero) {
                // Idle
                // Idle();
                Debug.Log("Idles");
                animator.SetFloat("Speed", 0);
            }

            // This functions returns the NetworkInputData object
            // Create NetWorkInputData script

            // Only move when there is network input
            // To receive input check the CharacterInputHandler() script

            //Move

            // THIS CODE BREAKS

            // Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;
            // moveDirection.Normalize();
            // networkCharacterControllerPrototypeCustom.Move(moveDirection);

            // CODE ABOVE BREAK

            // CODE 2
            networkCharacterControllerPrototypeCustom.transform.Rotate(Vector3.up * networkInputData.movementInput.x * (100f * Time.deltaTime));

            networkCharacterControllerPrototypeCustom.Move(networkCharacterControllerPrototypeCustom.transform.forward * networkInputData.movementInput.z * moveSpeed * Time.deltaTime);

            // CODE 2

                    // OLD CODE
                // charController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

                // //char move
                // charController.Move(v_movement * moveSpeed * Time.deltaTime);
        }
    }

    // private void Idle()
    // {
    //     Debug.Log("Idles");
    //     animator.SetFloat("Speed", 0);
    // }

    // private void Walk()
    // {
    //     if(networkInputData.movementInput.x > -1 && networkInputData.movementInput.x < 0) {
    //         Debug.Log("Turns left");

    //     } else if(networkInputData.movementInput.x > 0 && networkInputData.movementInput.x < 1) {
    //         Debug.Log("Turns Right");

    //     }
    //     else {
    //         animator.SetFloat("Speed", 0.5f);
    //     }

    //     v_movement = charController.transform.forward * networkInputData.movementInput.z;

    //     Debug.Log("Walks");
    //     moveSpeed = walkSpeed;
    // }

    // private void Run()
    // {
    //     moveSpeed = runSpeed;
    //     // // 0,1f + Time.deltaTime is going to smoothen the animation
    //     animator.SetFloat("Speed", 1);
    // }


}
