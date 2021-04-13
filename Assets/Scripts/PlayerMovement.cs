using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerialzieField] private float runSpeed;

    private Vector3 moveDirection;

    // References
    private CharacterController controller;


}
