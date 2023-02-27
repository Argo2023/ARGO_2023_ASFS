using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("AI"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
