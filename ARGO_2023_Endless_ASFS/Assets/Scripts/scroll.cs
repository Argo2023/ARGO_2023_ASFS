using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
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

        if (transform.position.x+ width / 2 <= -12)
        {
            SetPosition(width);
        }
    }

    
    public void SetPosition(float t_position)
    {
        transform.position = new Vector3(t_position, transform.position.y, 0f);
    }
}

