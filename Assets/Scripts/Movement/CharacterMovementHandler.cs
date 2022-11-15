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

    private float gravity = 3f;

    private void Awake()
    {
        // Fetch network character controller
        charController = GetComponent<CharacterController>();
        // animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
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

                // This works but character floats above ground
                //  networkInputData.movementInput *= moveSpeed;
                // charController.Move(networkInputData.movementInput);
                if(charController.isGrounded)
                {
                    Debug.Log("Character is grounded!");
                    networkInputData.movementInput *= moveSpeed;
                }

                // Use this to ground the character
                networkInputData.movementInput.y -= gravity;

                charController.Move(networkInputData.movementInput * Time.deltaTime);
            }
    }
}
