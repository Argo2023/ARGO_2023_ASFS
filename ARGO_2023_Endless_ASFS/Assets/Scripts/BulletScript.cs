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
    /// <summary>
    /// Checks for collision between bullet and AI.
    /// If AI is collided with, take away health from AI
    /// If AI health is less than or equal to 0, destroy it
    /// add 10 score to the game
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            Destroy(gameObject);
            //collision.gameObject.GetComponent<HealthScript>().baseHealth -= 2;
            collision.gameObject.GetComponent<HealthScript>().entityTakesDamage(collision.gameObject.GetComponent<HealthScript>().shotDamage);
            Destroy(collision.gameObject);
            

            if (collision.gameObject.GetComponent<HealthScript>().baseHealth <= 0)
            {
                Destroy(collision.gameObject);
            }

            gameLoop.score += 10;
        }

        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        //    Destroy(gameObject);
        //}
    }

}
