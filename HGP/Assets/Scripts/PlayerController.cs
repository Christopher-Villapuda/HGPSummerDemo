using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 25;
    //private float xRange = 30;
    //private float yRange = 30;
    private float xSpeed;
    private float ySpeed;
    private Vector2 velocity;
    private Rigidbody2D rBD2D;
    // Start is called before the first frame update
    void Start()
    {
        rBD2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x < -xRange)
        //{
        //    transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        //}

        //if (transform.position.x > xRange)
        //{
        //    transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        //}

        //rBD2D.MovePosition(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //if (transform.position.y < -yRange)
        //    {
        //        transform.position = new Vector3(transform.position.x,- yRange, transform.position.z);
        //    }

        //if (transform.position.y > yRange)
        //    {
        //        transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        //    }
        //rBD2D.MovePosition(Vector3.up * verticalInput * Time.deltaTime * speed);

        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        xSpeed = speed * horizontalInput * Time.deltaTime;
        ySpeed = speed * verticalInput * Time.deltaTime;

        velocity = new Vector2(xSpeed, ySpeed);

        rBD2D.MovePosition(rBD2D.position + velocity);
    }
}
