using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector2 targetVector;
    //private Vector2 targetVectoerStorage;
    private Rigidbody2D rBD2D;
    private Vector2 additionalVelocity;
    //private Vector2 enemy;
    [SerializeField]
    private float speed = 10.0f;
    private RaycastHit2D hit;
    private float horizontalDirection;
    private float verticalDirection;
    private float directionRayDistance = 2;

    void Start()
    {
        //targetVector = target.position;
        //enemy = transform.position;
        rBD2D = GetComponent<Rigidbody2D>();
        targetVector = target.position;
    }
    void Update()
    {
        //Sets up the distance moved this frame.
        float step = speed * Time.deltaTime;

        //Casts a ray towards the player.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ((Vector2)target.position - (Vector2)transform.position),300);
        //Draws a ray towards the position the enemy is moving towards
        Debug.DrawRay(transform.position, (targetVector - (Vector2)transform.position), Color.red);
        //Prints the name of the hit object.
        //Debug.Log(hit.collider.gameObject.tag);
        //If the cast ray hits the player, the position the enemy is moving towards updates.
        if (hit.collider.gameObject.tag == "Player")
        {
            targetVector = target.position;
        }
        //else if (hit.collider.gameObject.tag == "Prop")
        //{
        //    additionalVelocity = transform.up * step;
        //}

        //if (Input.GetKey("space"))
        //{
        //    additionalVelocity = transform.right * step;
        //    Debug.Log("Trying to move right");
        //}

        horizontalDirection = Mathf.Sign(transform.position.x - targetVector.x);
        verticalDirection = Mathf.Sign(transform.position.y - targetVector.y);

        //Moves the enemy towards the targeted position.
        rBD2D.MovePosition(Vector2.MoveTowards(transform.position, targetVector, step) + additionalVelocity);

        additionalVelocity = new Vector2(0, 0);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        var bounds = GetComponent<BoxCollider2D>().bounds.extents;
        var xExtent = new Vector2(bounds.x, 0);
        var yExtent = new Vector2(0, bounds.y);
        //Get this shit cleaned up and put this shit in an if statement to make it usable.
        Debug.DrawLine((Vector2)transform.position + yExtent + (Vector2)transform.right * directionRayDistance, (Vector2)transform.position + yExtent - (Vector2)transform.right * directionRayDistance);
        Debug.DrawLine((Vector2)transform.position - yExtent + (Vector2)transform.right * directionRayDistance, (Vector2)transform.position - yExtent - (Vector2)transform.right * directionRayDistance);
        Debug.DrawLine((Vector2)transform.position + xExtent + (Vector2)transform.up * directionRayDistance, (Vector2)transform.position + xExtent - (Vector2)transform.up * directionRayDistance);
        Debug.DrawLine((Vector2)transform.position - xExtent + (Vector2)transform.up * directionRayDistance, (Vector2)transform.position - xExtent - (Vector2)transform.up * directionRayDistance);
        if (Physics2D.Linecast(transform.position + transform.right * directionRayDistance,transform.position - transform.right * directionRayDistance))
        {
            

        }
        if (Physics2D.Linecast(transform.position + transform.up * directionRayDistance, transform.position - transform.up * directionRayDistance))
        {
            

        }
        if (other.gameObject.tag == "Prop")
        {
            additionalVelocity = transform.up * speed * Time.deltaTime;
        }
    }
}
