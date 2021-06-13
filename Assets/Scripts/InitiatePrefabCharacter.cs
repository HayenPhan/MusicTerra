using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiatePrefabCharacter : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        GameObject playerInstance = Instantiate(playerPrefab);
        playerInstance.transform.position = Vector3.zero;
    }
}
