using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    private int speed = 2;
    private int width = 24;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -width)
        {
            SetPosition(width);
        }
    }

    
    public void SetPosition(float t_position)
    {
        transform.position = new Vector3(t_position, transform.position.y, 0f);
    }
}

