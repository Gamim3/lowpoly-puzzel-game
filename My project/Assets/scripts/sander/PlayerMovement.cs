using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float x;
    float z;
    Vector3 move;

    Vector3 velocity;
    bool isGrounded;

    public bool inMenu;

    // Update is called once per frame
    void Update()
    {
        if (inMenu == true)
        {
            x = 0;
            z = 0;
            move.x = 0;
            move.z = 0;
        }
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (inMenu == false)
        {
            move = transform.right * x + transform.forward * z;
        }

        controller.Move(move * speed * Time.deltaTime);

        if(inMenu == false)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
