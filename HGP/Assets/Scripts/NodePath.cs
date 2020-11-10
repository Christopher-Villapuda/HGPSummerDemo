using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePath : MonoBehaviour
{
    [SerializeField]
    List<GameObject> nodes;
    float speed = 5.0f;
    int nodeCount = 0;

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, nodes[nodeCount].transform.position, step);

        if ((Vector2)transform.position == (Vector2)nodes[nodeCount].transform.position)
        {
            if (nodeCount + 1 == nodes.Count)
            {
                nodeCount = 0;
            }
            else
            {
                nodeCount++;
            }
        }
        Debug.Log(transform.position + " " + nodes[nodeCount].transform.position);
    }
}
