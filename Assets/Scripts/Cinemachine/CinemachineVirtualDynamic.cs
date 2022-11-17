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

        // Follow player   localplayer.transform
        // cinemachineVirtualCamera.Follow =
        // cinemachineVirtualCamera.LookAt

        StartCoroutine(CharacterSpawned());
    }

    IEnumerator CharacterSpawned()
    {
        yield return new WaitForSeconds(2.5f);
        Debug.Log(Spawner.isSpawned);

        if(Spawner.isSpawned)
        {
            cinemachineVirtualCamera.Follow = NetworkPlayer.Local.transform;
            cinemachineVirtualCamera.LookAt = NetworkPlayer.Local.transform;
        }
    }
}
