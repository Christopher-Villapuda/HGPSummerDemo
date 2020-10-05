using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool hiding = false;
    private float originalXpos;
    private float originalYpos;
    private float newXpos;
    private float newYpos;
    private bool hideAction = false;

    void FixedUpdate()
    {
        if (hiding)
        {
            transform.position = new Vector2(newXpos, newYpos);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            hideAction = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (hideAction)
        {
            if (col.gameObject.tag == "Prop")
            {
                if (hiding)
                {
                    hiding = false;
                    transform.position = new Vector2(originalXpos, originalYpos);
                }
                else
                {
                    hiding = true;
                    newXpos = col.gameObject.transform.position.x;
                    newYpos = col.gameObject.transform.position.y;
                    originalXpos = transform.position.x;
                    originalYpos = transform.position.y;
                }
            }
            hideAction = false;
        }
    }
}
