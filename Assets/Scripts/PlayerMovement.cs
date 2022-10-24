using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;

    // References
    private CharacterController controller;
    private Animator anim;

    //Camera
    //[Range(-45, -15)]
    public int minAngle = -30;
    //[Range(30, 80)]
    public int maxAngle = 45;

    public int sensitivity = 200;
    private Transform cam;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        Debug.Log("Juisstset");
        // if (GameObject.Find ("Player [connId=0]" ) != null) {
        //     GameObject chatUIInstance = (GameObject)Instantiate(Resources.Load("ChatUI"));
        //     Debug.Log(chatUIInstance);
        // } else {
        //     Debug.Log ("not there");
        // }
        //     if (GameObject.Find ("Player(Clone)" ) != null) {
        //     Debug.Log ("clone");
        // } else {
        //     Debug.Log ("not there clone");
        // }
    }

    private void HandleMovement() {
        Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
        // cameraTransform.parent = CameraMountPoint.main.gameObject.transform;  //Make the camera a child of the mount point
        cameraTransform.position = Camera.main.gameObject.transform.position;  //Set position/rotation same as the mount point
        cameraTransform.rotation = Camera.main.transform.rotation;

        // Forward en Backwards
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        // x, y, z <-- used this code first
        //moveDirection = new Vector3(moveX, 0, moveZ);

        // x, y, z <-- Add camera main forward and right to move character in the direction of the camera.
        // If you don't do this, your character will move the opposite direction, because it doesn't know the position of the camera.
        moveDirection = Camera.main.transform.forward * moveZ + Camera.main.transform.right * moveX;

        // Makes the player move in the right directions even when rotating with mouse
        // moveDirection = transform.TransformDirection(moveDirection);

        // If walkspeed is 5, moveZ will be multiplied by 5. So it walks 5 times faste
        // moveDirection *= walkSpeed;

        // If our movement is not equal to 0, 0, 0 then..
        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            // Walk
            Walk();
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
            Run();
        }
        else if(moveDirection == Vector3.zero)
        {
            // Idle
            Idle();
        }

        // // Multiply direction with wanted speed
        moveDirection *= moveSpeed;


        // Time.delta -> doesn't matter how many frames you have, you will still move the same amount of time.
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Update()
    {
        // if(Camera.main != null) {
        //      Move();
        // }

        // if(Camera.main != null) {
        //     Move();
        // }
         if(Camera.main != null) {
            HandleMovement();
            Rotate();
         } else {
            Debug.Log("CAMERA IS NULL");
         }
    }

    private void Move()
    {
        // Forward en Backwards
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        // x, y, z <-- used this code first
        //moveDirection = new Vector3(moveX, 0, moveZ);

        // x, y, z <-- Add camera main forward and right to move character in the direction of the camera.
        // If you don't do this, your character will move the opposite direction, because it doesn't know the position of the camera.
            moveDirection = Camera.main.transform.forward * moveZ + Camera.main.transform.right * moveX;

            // Makes the player move in the right directions even when rotating with mouse
            // moveDirection = transform.TransformDirection(moveDirection);

            // If walkspeed is 5, moveZ will be multiplied by 5. So it walks 5 times faste
            // moveDirection *= walkSpeed;

            // If our movement is not equal to 0, 0, 0 then..
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                // Walk
                Walk();
            }
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
                Run();
            }
            else if(moveDirection == Vector3.zero)
            {
                // Idle
                Idle();
            }

            // // Multiply direction with wanted speed
            moveDirection *= moveSpeed;


            // Time.delta -> doesn't matter how many frames you have, you will still move the same amount of time.
            controller.Move(moveDirection * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        // Missing code
        anim.SetFloat("Speed", 0.8f, 01f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        // 0,1f + Time.deltaTime is going to smoothen the animation
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    // Camera rotation

    private void Rotate()
    {
        // FIX THIS!!!
        transform.Rotate(Vector3.up * sensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));

        moveDirection.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        moveDirection.x = Mathf.Clamp(moveDirection.x, minAngle, maxAngle);

        cam.localEulerAngles = moveDirection;
    }
}
