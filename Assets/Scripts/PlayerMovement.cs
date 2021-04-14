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

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Forward en Backwards
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        // x, y, z
        moveDirection = new Vector3(moveX, 0, moveZ);

        // If walkspeed is 5, moveZ will be multiplied by 5. So it walks 5 times faste
        moveDirection *= walkSpeed;

        // Time.delta -> doesn't matter how many frames you have, you will still move the same amount of time.
        controller.Move(moveDirection * Time.deltaTime);
    }

}
