using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisions : MonoBehaviour
{

    /// <summary>
    /// properties of the particle collisions
    /// </summary>
    public bool particlePlaying = false;
    public GameObject impact;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// when the bullet collides with anything that the player is surrounded with, a particle of impact then is spawned at a location that they colided on.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" ||
            collision.gameObject.tag == "Ground" ||
            collision.gameObject.tag == "AI")
        {
            Instantiate(impact, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            particlePlaying = true;
        }
    }
}
