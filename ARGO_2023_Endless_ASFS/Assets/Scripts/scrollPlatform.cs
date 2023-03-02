using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollPlatform : MonoBehaviour
{
    [SerializeField]
    public scroll floor;
    private int speed = 2;
    private float width;
    // Start is called before the first frame update
    void Start()
    {
        width = transform.localScale.x;
        floor = FindObjectOfType<scroll>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.left * floor.speed *200 * Time.deltaTime;

        if (transform.position.x + width / 2 <= -12)
        {
            Destroy(gameObject);
        }
    }
}
