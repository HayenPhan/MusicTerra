using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    // Script is added to Player prefab

    // public Vector3 moveInputVector;
    // private CharacterController charController;

    // Start is called before the first frame update

    Vector2 moveInputVector = Vector2.zero;

    void Start()
    {
        // charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // //Move input
        // moveInputVector.x = Input.GetAxis("Horizontal");
        // // moveInputVector.z = Input.GetAxis("Vertical");
        // moveInputVector.z = Input.GetAxis("Vertical");

        //  // Place keyboard input X and Z in moveDirection
        // moveInputVector = new Vector3(moveInputVector.x, 0, moveInputVector.z);

         //Move input
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");
    }

    public NetworkInputData GetNetworkInput()
    {
        // When the network is ready you pass along the movement input tot he network
        // Go to Spawner script to handle this data in the OnInput function
        // At the top of the spawner script stark looking at this first: CharacterInputHandler characterInputHandler;

        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.movementInput = moveInputVector;
        networkInputData.rotationInput = moveInputVector.x;

        return networkInputData;
    }
}
