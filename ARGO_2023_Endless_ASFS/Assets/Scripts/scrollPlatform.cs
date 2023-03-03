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
    /// <summary>
    /// In start function we just find references to the objects
    /// </summary>
    void Start()
    {
        width = transform.localScale.x;
        floor = FindObjectOfType<scroll>();
    }


    /// <summary>
    /// here in update we continuesly add the speed of the floor to the platforms so the game moves at the same paste
    /// </summary>
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
