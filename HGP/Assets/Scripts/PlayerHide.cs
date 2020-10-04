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

    void FixedUpdate()
    {
        if (hiding)
        {
            transform.position = new Vector2(newXpos, newYpos);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (Input.GetKeyDown("space") && col.gameObject.tag == "Prop")
        {
            if (!hiding)
            {
                hiding = true;
                newXpos = col.gameObject.transform.position.x;
                newYpos = col.gameObject.transform.position.y;
                originalXpos = transform.position.x;
                originalYpos = transform.position.y;
            }
            else
            {
                hiding = false;
                transform.position = new Vector2(originalXpos, originalYpos);
            }
        }
    }
}
