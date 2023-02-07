using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that will handling all of the changing of states for the AI
/// Each state will determine how the AI will behave towards the player
/// THIS VERSION IS FOR THE MULTI-PLAYER MODE!!!!!
/// </summary>

enum AIState
{
    IDLE,
    ATTACKING,
    CHASING,
    EVADING
};


public class AIScript : MonoBehaviour
{
    AIState state = AIState.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthScript>().initializePlayer(100, 10); // Initialises the player
    }

    // Update is called once per frame
    void Update()
    {
        setEntityState(); // Asks the AI which state is it in



    }


    /// <summary>
    /// Returns the state the AI should be in, depending on the Health Points the AI currently has
    /// </summary>
    /// <returns></returns>
    /// 
    AIState setEntityState()
    {
        if (GetComponent<HealthScript>().baseHealth > 70)
        {
            state = AIState.ATTACKING;
        }

        if (GetComponent<HealthScript>().baseHealth < 70)
        {
            state = AIState.CHASING;
        }

        if (GetComponent<HealthScript>().baseHealth < 40)
        {
            state = AIState.EVADING;
        }


        ///
        /// Enable when there is a way to count all of the entities on the screen without including the current one
        //if (enemyCount < 1)
        //{
        //    state = AIState.IDLE;
        //}


        return state;
    }


    /// <summary>
    /// Activates a specific behaviour for the AI based on the state the AI is currently in
    /// </summary>
    /// 
    void setAIAction()
    {
        if (state == AIState.ATTACKING)
        {
            // call functions for the AI to attack the player
        }

        if (state == AIState.CHASING)
        {
            // call functions for AI chasing the player
        }

        if (state == AIState.EVADING)
        {
            // call functions for the AI to evade all of the enemies
        }
    }
}
