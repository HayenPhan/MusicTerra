using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;


// 2: Handling the spawning of network objects
// Network Runner PF object is selected in Network Runner Handler script in NetworkRunnerHandler object in unity.
// After initialization in NetWorkRunnerHandler add Spawner script to Network Runner PF object

public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    // To spawn a player a prefab is needed
    public NetworkPlayer playerPrefab;

    // Other components
    CharacterInputHandler characterInputHandler;

    public static bool isSpawned { get; set; }

    // Start is called before the first frame update

    void Start()
    {

    }

    private void Awake() {

    }

    public void OnConnectedToServer(NetworkRunner runner) { Debug.Log("OnConnectedToServer");  }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // This is what going to spawn players in the world
        // When the player is joining and WE are the server:

        // ERROR: 'NetworkRunner' does not contain a definition for 'isServer' and no accessible extension method 'isServer'
        //accepting a first argument of type 'NetworkRunner' could be found (are you missing a using directive or an assembly reference?)

                    // Player is spawned
        if(runner.IsServer)
        {
            Debug.Log("OnPlayerJoined we are server. Spawn player");

            // Vector3 spawnPosition = new Vector3((player.RawEncoded%runner.Config.Simulation.DefaultPlayers)*3,1,0);

            // int i = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);
            // var playerAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), GameManager.instance.spawnPoints[i].position, Quaternion.identity);

            // Quaternion will make sure that the player faces forward
            runner.Spawn(playerPrefab, Utils.GetRandomSpawnPoint(), Quaternion.identity, player);
            isSpawned = true;
        }
        else Debug.Log("OnPlayerJoined");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

        // Collect our input and send it to the network so the host can take care of it and act upon it
        // Check if you are getting the CharacterController from the right player

        // If CharacterController(characterInputHandler) is not assigned yet (==null) && a local player is active
        if (characterInputHandler == null && NetworkPlayer.Local != null)
            // Get CharacterInputHandler and assign it to characterInputHandler
            characterInputHandler = NetworkPlayer.Local.GetComponent<CharacterInputHandler>();

        if (characterInputHandler != null)
            input.Set(characterInputHandler.GetNetworkInput());
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
