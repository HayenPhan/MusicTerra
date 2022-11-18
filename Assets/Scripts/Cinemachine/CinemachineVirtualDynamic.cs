using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent (typeof(CinemachineVirtualCamera))]

public class CinemachineVirtualDynamic : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        // Get a reference of the virtual camera
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        StartCoroutine(CharacterSpawned());
    }

    IEnumerator CharacterSpawned() {
        yield return new WaitUntil(() => Spawner.isSpawned == true);

        cinemachineVirtualCamera.Follow = NetworkPlayer.Local.transform;
        cinemachineVirtualCamera.LookAt = NetworkPlayer.Local.transform;
    }
}
