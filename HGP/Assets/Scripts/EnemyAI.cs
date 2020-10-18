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
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        var bounds = GetComponent<BoxCollider2D>().bounds.extents;
        var xExtent = new Vector2(bounds.x, 0);
        var yExtent = new Vector2(0, bounds.y);
        Vector2[] lineCastDimensions = new Vector2[8];
        lineCastDimensions[0] = (Vector2)transform.position + yExtent + (Vector2)transform.right * directionRayDistance;
        lineCastDimensions[1] = (Vector2)transform.position + yExtent - (Vector2)transform.right * directionRayDistance;
        lineCastDimensions[2] = (Vector2)transform.position - yExtent + (Vector2)transform.right * directionRayDistance;
        lineCastDimensions[3] = (Vector2)transform.position - yExtent - (Vector2)transform.right * directionRayDistance;
        lineCastDimensions[4] = (Vector2)transform.position + xExtent + (Vector2)transform.up * directionRayDistance;
        lineCastDimensions[5] = (Vector2)transform.position + xExtent - (Vector2)transform.up * directionRayDistance;
        lineCastDimensions[6] = (Vector2)transform.position - xExtent + (Vector2)transform.up * directionRayDistance;
        lineCastDimensions[7] = (Vector2)transform.position - xExtent - (Vector2)transform.up * directionRayDistance;

        //Get this shit cleaned up and put this shit in an if statement to make it usable.
        Debug.DrawLine(lineCastDimensions[0], lineCastDimensions[1]);
        Debug.DrawLine(lineCastDimensions[2], lineCastDimensions[3]);
        Debug.DrawLine(lineCastDimensions[4], lineCastDimensions[5]);
        Debug.DrawLine(lineCastDimensions[6], lineCastDimensions[7]);
        if (Physics2D.Linecast(lineCastDimensions[0], lineCastDimensions[1], layerMask)
            || Physics2D.Linecast(lineCastDimensions[2], lineCastDimensions[3], layerMask)
            || Physics2D.Linecast(lineCastDimensions[1], lineCastDimensions[0], layerMask)
            || Physics2D.Linecast(lineCastDimensions[3], lineCastDimensions[2], layerMask))
        {
            Debug.Log("Bumping horizontal lines");

        }
        if (Physics2D.Linecast(lineCastDimensions[4], lineCastDimensions[5], layerMask) 
            || Physics2D.Linecast(lineCastDimensions[6], lineCastDimensions[7], layerMask)
            || Physics2D.Linecast(lineCastDimensions[5], lineCastDimensions[4], layerMask)
            || Physics2D.Linecast(lineCastDimensions[7], lineCastDimensions[6], layerMask))
        {
            Debug.Log("Bumping vertical lines");

        }
        if (other.gameObject.tag == "Prop")
        {
            additionalVelocity = transform.up * speed * Time.deltaTime;
        }
    }
}
