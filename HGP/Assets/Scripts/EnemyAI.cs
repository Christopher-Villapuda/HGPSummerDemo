using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector2 targetVector;
    private Rigidbody2D rBD2D;
    //private Vector2 enemy;
    [SerializeField]
    private float speed = 10.0f;

    void Start()
    {
        //targetVector = target.position;
        //enemy = transform.position;
        rBD2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        targetVector = target.position;

        rBD2D.MovePosition(Vector2.MoveTowards(transform.position, targetVector, step));
    }
}
