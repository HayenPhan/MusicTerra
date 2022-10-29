using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update() {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
    // public float pLerp = .02f;
    // public float rLerp = .01f;

    // void Update()
    // {
    //     transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
    // }

    // // Variables
    // [SerializeField] private float mouseSensitivity;

    // // // // References
    // public Transform parent;

    // private void Start()
    // {

    //     // Parent is the Player
    //     parent = transform.parent;

    //     // Cursor.lockState = CursorLockMode.Locked;
    // }

    // private void Update()
    // {
    //     Rotate();
    // }

    // private void Rotate()
    // {
    //     float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

    //     parent.Rotate(Vector3.up, mouseX);
    // }

}
