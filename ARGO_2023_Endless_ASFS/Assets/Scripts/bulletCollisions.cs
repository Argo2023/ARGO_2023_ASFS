using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisions : MonoBehaviour
{
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
