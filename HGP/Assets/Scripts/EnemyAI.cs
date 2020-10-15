using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector2 targetVector;
    private Vector2 targetVectoerStorage;
    private Rigidbody2D rBD2D;
    //private Vector2 enemy;
    [SerializeField]
    private float speed = 10.0f;
    private RaycastHit2D hit;

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
        Debug.Log(hit.collider.gameObject.tag);
        //If the cast ray hits the player, the position the enemy is moving towards updates.
        if (hit.collider.gameObject.tag == "Player")
        {
            targetVector = target.position;
        }
        else if (hit.collider.gameObject.tag == "Prop")
        {
            //Here I will store the orignal vector and plot out the new vectors for getting around the prop.
        }

        //Moves the enemy towards the targeted position.
        rBD2D.MovePosition(Vector2.MoveTowards(transform.position, targetVector, step));
    }
}
