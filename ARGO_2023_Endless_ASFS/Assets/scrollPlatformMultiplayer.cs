using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class scrollPlatformMultiplayer : NetworkBehaviour
{
    private int speed = 2;
    private float width;
    /// <summary>
    /// sets the width of a platform to scroll 
    /// </summary>
    void Start()
    {
        width = transform.localScale.x;
    }

    /// <summary>
    /// scrolls the platform to the left
    /// if the platform goes too far left destroy it 
    /// </summary>
    void FixedUpdate()
    {
        //if (!isServer)
        //{
        //    return;
        //}

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x + width / 2 <= -12)
        {
            Destroy(gameObject);
        }
    }
}
