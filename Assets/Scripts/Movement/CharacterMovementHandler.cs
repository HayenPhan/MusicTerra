using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    // Script is added to Player prefab
    // Other components
    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;

    private void Awake()
    {
        // Fetch network character controller
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
    }
    // Start is called before the first frame update
    void Start()
    {

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

        //Get the input from the network
        if(GetInput(out NetworkInputData networkInputData))
        {
            // This functions returns the NetworkInputData object
            // Create NetWorkInputData script

            // Only move when there is network input
            // To receive input check the CharacterInputHandler() script

            //Move
            Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;
            moveDirection.Normalize();

            networkCharacterControllerPrototypeCustom.Move(moveDirection);
        }

    }
}
