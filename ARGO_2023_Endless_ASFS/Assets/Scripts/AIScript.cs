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

enum Actions
{
    JUMP,
    SHOOT,
    MOVE
};


public class AIScript : MonoBehaviour
{
    public bool jumpTrigger = false;
    public Rigidbody2D rb;
    public float speed = 2.0f;
    List<Actions> actions = new List<Actions>();
    AIState state = AIState.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<HealthScript>().initializePlayer(100, 10); // Initialises the player
    }

    // Update is called once per frame
    void Update()
    {
        setEntityState(); // Asks the AI which state is it in
        setAIAction();
        actionExecution(actions);
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

        if (GetComponent<HealthScript>().baseHealth <= 0)
        {
            state = AIState.IDLE;
        }

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

        if (state == AIState.IDLE)
        {
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ME IZ HERE");
        if (collision.gameObject.CompareTag("wall"))
        {
            jumpTrigger = true;
            speed = -speed;
        }
    }


    void actionExecution(List<Actions> t_actions)
    {

        if (t_actions[0] == Actions.MOVE)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        if (t_actions[0] == Actions.SHOOT)
        {
            // code for shoot
        }
        if (t_actions[0] == Actions.JUMP)
        {
            rb.AddForce(Vector2.up * 5.0f, ForceMode2D.Impulse);
            t_actions.RemoveAt(0);
        }
        if (jumpTrigger)
        {
            jumpTrigger = false;
            t_actions.RemoveAt(0);
        }
    }

}
