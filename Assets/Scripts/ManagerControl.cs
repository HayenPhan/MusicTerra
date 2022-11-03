using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerControl : MonoBehaviour
{
    //component
    private CharacterController charController;
    private Animator animator;

    // var move
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private Vector3 v_velocity;
    private float moveSpeed;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        // component
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        charController = tempPlayer.GetComponent<CharacterController>();
        animator = tempPlayer.transform.GetChild(0).GetComponent<Animator>();

        //etc
        moveSpeed = 4f;
        gravity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        // input forward
        v_movement = charController.transform.forward * inputZ;

        // char rotate
        charController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        //char move
        charController.Move(v_movement * moveSpeed * Time.deltaTime);
    }
}
