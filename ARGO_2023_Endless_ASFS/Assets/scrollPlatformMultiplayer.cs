using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class scrollPlatformMultiplayer : NetworkBehaviour
{
    private int speed = 2;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        if (!isServer)
        {
            return;
        }

        width = transform.localScale.x;
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isServer)
        {
            return;
        }

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x + width / 2 <= -12)
        {
            Destroy(gameObject);
        }
    }
}
