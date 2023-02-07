using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a base script that will handle taking damage and altering heatlh for each character in the game
/// initialisePlayer() sets up the player with health and damage it starts with, only needs to be called once for each character
/// 
/// </summary>
public class HealthScript : MonoBehaviour
{
    public GameObject entity;
    public float baseHealth; // this is the character health
    public float shotDamage; // this is the damage a character will deal with every shot


    /// <summary>
    /// Initialises the player
    /// Needs to be called everytime a new character is created
    /// </summary>
    /// <param name="t_health">Pass in the value for the character to be initialised with</param>
    /// <param name="t_damage">Pass in the value for the character to be initialised with</param>
    /// <returns>if return = 0 everything ran properly, 1 is an error</returns>
    public int initializePlayer(float t_health, float t_damage)
    {
        if (baseHealth == 0 && shotDamage == 0)
        {
            baseHealth = t_health;
            shotDamage = t_damage;
            return 0;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// function that needs to be called if the character takes damage.
    /// pass in the value for damage to damage the entity
    /// </summary>
    /// <param name="t_damage"></param>
    public void entityTakesDamage(float t_damage)
    {
        baseHealth = baseHealth - t_damage;

        if (isEntityDead())
        {
            Destroy(entity); // Destroys the entity this script is attached to
        }
    }

    /// <summary>
    /// Checks if the entity health is 0
    /// Returns if the Entity is Dead or Alive
    /// </summary>
    /// <returns>alive/dead</returns>
    public bool isEntityDead()
    {
        if (baseHealth <= 0)  
            return true;       
        else
            return false;
    }
}
