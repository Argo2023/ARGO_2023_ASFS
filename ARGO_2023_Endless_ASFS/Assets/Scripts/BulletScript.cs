using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public gameLoop gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<gameLoop>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<HealthScript>().baseHealth -= 2;

            if(collision.gameObject.GetComponent<HealthScript>().baseHealth <= 0)
            {
                Destroy(collision.gameObject);
            }

            gameLoop.score += 10;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
