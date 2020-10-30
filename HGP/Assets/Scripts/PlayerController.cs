using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AnimatorController playerMovingLeft;
    [SerializeField]
    private AnimatorController playerMovingRight;
    [SerializeField]
    private AnimatorController playerLeftIdle; // Plug in idle animation if you want!
    [SerializeField]
    private AnimatorController playerRightIdle;

    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    //private float xRange = 30;
    //private float yRange = 30;
    private float xSpeed = 0f;
    private float ySpeed = 0f;
    [SerializeField]
    private float sprint = 5;
    private float sprintSpeed;
    [SerializeField]
    private float maxStamina = 5;
    [SerializeField]
    private float staminaDrain = 0.1f;
    [SerializeField]
    private float staminaGain = 0.2f;
    private float stamina;
    private bool exhausted = false;
    private Vector2 velocity;
    private Rigidbody2D rBD2D;

    private Animator playerAnimator;

    // Start is called before the first frame update

    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rBD2D = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
        //SetNoMovingAnimBool();
    }

    //void Start()
    //{
    //    rBD2D = GetComponent<Rigidbody2D>();
    //}

    
    void FixedUpdate()
    {
        if (!exhausted)
        {
            if (Input.GetKey("left shift"))
            {
                sprintSpeed = sprint;
                stamina -= staminaDrain;
                if (stamina < 0)
                {
                    exhausted = true;
                }
            }
            else
            {
                sprintSpeed = 1;
                if (stamina < maxStamina)
                {
                    stamina += staminaGain;
                }
            }
        }
        else
        {
            sprintSpeed = 0.5f;
            stamina += staminaGain;
            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
                exhausted = false;
            }
        }

        Vector2 position = transform.position;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        position.x = position.x + speed * horizontalInput * Time.deltaTime * sprintSpeed;
        position.y = position.y + speed * verticalInput * Time.deltaTime * sprintSpeed;

        //xSpeed = speed * horizontalInput * Time.deltaTime;
        //ySpeed = speed * verticalInput * Time.deltaTime;

        //velocity = new Vector2(xSpeed, ySpeed);

        if (horizontalInput != 0)
        {
            if (horizontalInput > 0) // towards 1 = right
            {
                Debug.Log("The player is moving right.");
                playerAnimator.runtimeAnimatorController = playerMovingRight;
                //SetMovingRightAnimBool();
            }
            else if (horizontalInput < 0)  // towards -1 = left
            {
                Debug.Log("The player is moving left.");
                playerAnimator.runtimeAnimatorController = playerMovingLeft;
                //SetMovingLeftAnimBool();
            }
        }
        else if (horizontalInput == 0)
        {
            if (playerAnimator.runtimeAnimatorController == playerMovingRight)
            {
                playerAnimator.runtimeAnimatorController = playerRightIdle;
            }
            else if (playerAnimator.runtimeAnimatorController == playerMovingLeft)
            {
                playerAnimator.runtimeAnimatorController = playerLeftIdle;
            }
        }
        if (verticalInput != 0)
        {
            //if (horizontalInput > 0) // towards 1 = right
            //{
            //    Debug.Log("The player is moving right.");
            //    playerAnimator.runtimeAnimatorController = playerMovingRight;
            //    //SetMovingRightAnimBool();
            //}
            //else if (horizontalInput < 0)  // towards -1 = left
            //{
            //    Debug.Log("The player is moving left.");
            //    playerAnimator.runtimeAnimatorController = playerMovingLeft;
            //    //SetMovingLeftAnimBool();
            //}
        }
        else if (verticalInput == 0)
        {
            //if (playerAnimator.runtimeAnimatorController == playerMovingRight)
            //{
            //    playerAnimator.runtimeAnimatorController = playerRightIdle;
            //}
            //else if (playerAnimator.runtimeAnimatorController == playerMovingLeft)
            //{
            //    playerAnimator.runtimeAnimatorController = playerLeftIdle;
            //}
        }



        //rBD2D.MovePosition(rBD2D.position + velocity);
        rBD2D.MovePosition(position);
    }

    private void SetNoMovingAnimBool()
    {
        playerAnimator.SetBool("MovingLeft", false);
        playerAnimator.SetBool("MovingRight", false);
        playerAnimator.SetBool("MovingUp", false);
        playerAnimator.SetBool("MovingDown", false);
    }
    private void SetMovingLeftAnimBool()
    {
        playerAnimator.SetBool("MovingLeft", true);
        playerAnimator.SetBool("MovingRight", false);
        playerAnimator.SetBool("MovingUp", false);
        playerAnimator.SetBool("MovingDown", false);
    }
    private void SetMovingRightAnimBool()
    {
        playerAnimator.SetBool("MovingRight", true);
        playerAnimator.SetBool("MovingLeft", false);
        playerAnimator.SetBool("MovingUp", false);
        playerAnimator.SetBool("MovingDown", false);
    }
}
