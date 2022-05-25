using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private bool isSprinting => canSprint && Input.GetKey(sprintKey);
    private bool canSprint = true;
    private bool crouching = false;
    private KeyCode sprintKey = KeyCode.LeftShift;

    public Animator anim;

    public float crouchSpeed = 0f;
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

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (anim != null)
            {
                anim.SetBool("IsMoving",false);
            }
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 inputPlayer = new Vector3(hor, 0, ver);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (inputPlayer == Vector3.zero)
        {
            anim.SetBool("IsMoving", false);
        }
        else
        {
            anim.SetBool("IsMoving", true);
        }

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        canSprint = StaminaBar.instance.thereIsStamina;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.Move(move * crouchSpeed * Time.deltaTime);
        }
        else
        {
            
            controller.Move(move * (isSprinting ? runSpeed : walkSpeed) * Time.deltaTime);
        }
        

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
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                StaminaBar.instance.UseStamina(Time.deltaTime * sprintStamina);
            }  
        }

    }
}
