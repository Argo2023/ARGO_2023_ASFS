using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMultiplayer : MonoBehaviour
{
    /// <summary>
    /// Collision checker that checks collisions for the bullet and other objects
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.CompareTag("Player Multiplayer"))
        //{
        //    Debug.Log("Take Damage bro");
        //}

        if(collision.gameObject.CompareTag("Platform Multiplayer"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// An update function that will just destroy the bullet if the bullet has not collided with anything
    /// within 10 seconds
    /// </summary>
    private void Update()
    {
        Destroy(gameObject, 10.0f);
    }
}
