using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    //private float xRange = 30;
    //private float yRange = 30;
    private float xSpeed;
    private float ySpeed;
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
    // Start is called before the first frame update
    void Start()
    {
        rBD2D = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
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
        Debug.Log("Stamina: " + stamina + " Exhausted: " + exhausted);

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        xSpeed = speed * horizontalInput * Time.deltaTime;
        ySpeed = speed * verticalInput * Time.deltaTime;

        velocity = new Vector2(xSpeed, ySpeed);

        rBD2D.MovePosition(rBD2D.position + velocity * sprintSpeed);
    }
}
