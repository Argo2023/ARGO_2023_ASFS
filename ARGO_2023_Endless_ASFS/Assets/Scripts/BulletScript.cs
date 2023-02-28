using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public gameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<gameManager>();    
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

            gameManager.score += 10;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}