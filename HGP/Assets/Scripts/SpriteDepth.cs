using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDepth : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        //This sets the sorting order to an inverse of the y position (times 100 in order provide a larger difference between rounded numbers).
        //This means that something lower in the room will be drawn in front of something higher in the room.
        //This is meant to be applied to anything with a sprite renderer, so that all sprites are on the same page.
        //More importantly, it means the player character can easily go from being behind a prop to in front of the prop once 
        //they move lower in the room (or closer to the camera, as it is perceived).
        spriteRenderer.sortingOrder = 10000 - Mathf.RoundToInt(transform.position.y * 100);
    }
}
