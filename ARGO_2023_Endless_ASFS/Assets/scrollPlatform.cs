using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollPlatform : MonoBehaviour
{
    private int speed = 2;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        width = transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x + width / 2 <= -12)
        {
            Destroy(gameObject);
        }
    }
}
