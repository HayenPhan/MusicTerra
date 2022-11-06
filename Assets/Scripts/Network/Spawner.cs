using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;


// Handling the spawning of network objects
public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    // To spawn a player a prefab is needed
    public NetworkPlayer playerPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnConnectedToServer(NetworkRunner runner) { Debug.Log("OnConnectedToServer"); }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // This is what going to spawn players in the world
        // When the player is joining and WE are the server:

        // ERROR: 'NetworkRunner' does not contain a definition for 'isServer' and no accessible extension method 'isServer'
        //accepting a first argument of type 'NetworkRunner' could be found (are you missing a using directive or an assembly reference?)

        if(runner.IsServer)
        {
            Debug.Log("OnPlayerJoined we are server. Spawn player");

            // Quaternion will make sure that the player faces forward
            runner.Spawn(playerPrefab, Utils.GetRandomSpawnPoint(), Quaternion.identity, player);
        }
        else Debug.Log("OnPlayerJoined");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        // Collect our input and send it to the network so the host can take care of it and act upon it
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { Debug.Log("OnShutDown"); }
    public void OnDisconnectedFromServer(NetworkRunner runner) { Debug.Log("OnDisconnectedFromServer"); }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { Debug.Log("OnConnectedToServer"); }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { Debug.Log("OnConnectFailed"); }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
}
