using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float speed;
    public float jumpForce;
    private bool isGrounded = false;
    public float gravity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            direction.y = -2;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Jump();
        }
        else
            direction.y += gravity * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
}
