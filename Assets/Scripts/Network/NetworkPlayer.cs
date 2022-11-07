using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
// 3: Add this script to Player prefab
{
    // Make it easer to find the NetworkPlayer by using get and set method
    public static NetworkPlayer Local { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Called when player is spawned
    public override void Spawned()
    {
        // Check if we are controlling the object, which means that we have input authority
        // Execute code if the statement above is true
        // If we don't check this it will run on every client

        if (Object.HasInputAuthority)
        {
            // Store local player as a reference
            Local = this;

            Debug.Log("Spawned local player");
        }
        // If we don't have input authority it means that we are the REMOTE player
        else Debug.Log("Spawned remote player");
    }

    // Handle when player is leaving
    public void PlayerLeft(PlayerRef player)
    {
        if(player == Object.InputAuthority)
            Runner.Despawn(Object);
    }
}
