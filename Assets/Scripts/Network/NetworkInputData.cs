using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    // Photon recommends to use bits to control what is going on
    // Read the documentation to rewrite this code using bits
    // This code with vectors and floats is a temporary solution

    public Vector2 movementInput;
    // Find out what direction the player is facing with rotationInput
    public float rotationInput;
    // Allow the character to jump
    public NetworkBool isJumpPressed;

}
