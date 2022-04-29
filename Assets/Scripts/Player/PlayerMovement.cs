using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private bool isSprinting => canSprint && Input.GetKey(sprintKey);
    private bool canSprint = true;
    private KeyCode sprintKey = KeyCode.LeftShift;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float gravity = -10f;
    public float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector2 movement;

    Vector3 velocity;
    bool isGrounded;

    public float sprintStamina = 10f;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        canSprint = StaminaBar.instance.thereIsStamina;

        controller.Move(move * (isSprinting ? runSpeed : walkSpeed) * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -3)
        {
            transform.position = new Vector3(0, 3, -3);
        }

        if (!isGrounded && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
              velocity.y = -velocity.y;
        }

        if (Input.GetKey(sprintKey))
        {
            StaminaBar.instance.UseStamina(Time.deltaTime * sprintStamina);
        }
    }
}
