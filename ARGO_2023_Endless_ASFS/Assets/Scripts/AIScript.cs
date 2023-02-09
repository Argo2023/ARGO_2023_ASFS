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
    NOTHING,
    IDLE,
    ATTACKING,
    CHASING,
    EVADING
};

enum Actions
{
    JUMP,
    SHOOT,
    SPRINT,
    MOVE,
    ROLL
};


public class AIScript : MonoBehaviour
{
    public GameObject enemy;
    public bool jumpTrigger = false;
    public bool finished = false;
    public Rigidbody2D rb;
    public float speed = 1.0f;
    List<Actions> actions = new List<Actions>();
    AIState state = AIState.NOTHING;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthScript>().initializePlayer(69, 10); // Initialises the player
    }

    // Update is called once per frame
    void Update()
    {
        setAIAction();

        //Debug.Log(getEntityState());
        if (getEntityState() == AIState.ATTACKING)
        {
            attackingExecution(actions);
        }

        if (getEntityState() == AIState.CHASING)
        {
            chasingExecution(actions);
        }

        if (getEntityState() == AIState.EVADING)
        {
            evadingExecution(actions);
        }

        if (getEntityState() == AIState.IDLE)
        {
            idleExecution(actions);
        }
    }


    /// <summary>
    /// Returns the state the AI should be in, depending on the Health Points the AI currently has
    /// </summary>
    /// <returns></returns>
    /// 
    AIState getEntityState()
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
    /// To make work, add wanted actions to the ENUM class and then check for them in the necessary 
    /// Execution function and add behaviour
    /// </summary>
    /// 
    void setAIAction()
    {
        if (state == AIState.ATTACKING)
        {
            // add actions for the player to do while attacking
        }

        if (state == AIState.CHASING && finished != false)
        {
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
            finished = false;
        }

        if (state == AIState.EVADING)
        {
            // add actions for the player to do while evading
        }

        if (state == AIState.IDLE)
        {
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
        }
    }

    /// <summary>
    /// Changes the speed of the AI
    /// Turns the Jump Trigger to true so it can remove movement from the Actions list
    /// so Jump can be triggered
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            jumpTrigger = true;
            speed = -speed;
        }
    }

    /// <summary>
    /// This is a function that will handle how actions are executed. To make a more complex AI, we will need
    /// to add more triggers and handlers for each state the AI is in.
    /// </summary>
    /// <param name="t_actions"></param>
    void idleExecution(List<Actions> t_actions)
    {

        if (t_actions[0] == Actions.MOVE)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
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

    void evadingExecution(List<Actions> t_actions)
    {

    }

    void chasingExecution(List<Actions> t_actions)
    {
        //Debug.Log("Im here");
        if (t_actions[0] == Actions.MOVE)
        {
            if (!(transform.position.x - enemy.transform.position.x <= 1.0f))
            {
                Debug.Log(enemy.transform.position.x - transform.position.x);
                if (enemy.transform.position.x < transform.position.x)
                    transform.position -= Vector3.right * speed * Time.deltaTime;
                if(enemy.transform.position.x > transform.position.x)
                    transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                t_actions.RemoveAt(0);
            }
        }

        if (t_actions[0] == Actions.JUMP)
        {
            Debug.Log("HELLLOOOOO");
            rb.AddForce(Vector2.up * 5.0f, ForceMode2D.Impulse);
            t_actions.RemoveAt(0);
            finished = true;
        }

    }

    void attackingExecution(List<Actions> t_actions)
    {

    }

}
