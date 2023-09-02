using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        if (!PlayerManager1.isGameStarted)
            return;
        if (controller.isGrounded)
        {
            direction.y = -2;
            if (SwipeManager1.swipeUp)
                Jump();
        }
        else
            direction.y += gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!PlayerManager1.isGameStarted)
            return;

        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag=="Obstacle1")
        {
            PlayerManager1.gameOver = true;
        }
    } 
}
