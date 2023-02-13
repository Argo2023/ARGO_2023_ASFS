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
    ROLL,
    TILT
};


public class AIScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject platforms;
    public string transfer = "";
    public bool jumpTrigger = false;
    public bool grounded = true;
    public bool finished = true;
    public bool wee = false;
    public Rigidbody2D rb;
    public float speed = 1.0f;
    List<Actions> actions = new List<Actions>();
    List<GameObject> allPlatforms = new List<GameObject>();
    AIState state = AIState.NOTHING;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<HealthScript>().initializePlayer(69, 10); // Initialises the player
    }

    // Update is called once per frame
    void Update()
    {

        state = getEntityState();

        setAIAction();

        //Debug.Log(getEntityState());
        if (state == AIState.ATTACKING)
        {
            attackingExecution(actions);
        }

        if (state == AIState.CHASING)
        {
            chasingExecution(actions);
        }

        if (state == AIState.EVADING)
        {
            evadingExecution(actions);
        }

        if (state == AIState.IDLE)
        {
            idleExecution(actions);
        }

        if (Input.touchCount > 0)
        {
            GetComponent<HealthScript>().baseHealth = 39;

            getPlatforms();

            var tempBest = 0.0f;
            for (int i = 0; i < allPlatforms.Count; i++)
            {
                var distance = Vector2.Distance(transform.position, allPlatforms[i].transform.position);

                if (distance < tempBest)
                {
                    tempBest = distance;
                    Debug.Log("ID: " + i.ToString());
                }
            }
        }


        //Debug.Log(rb.velocity);
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

        if (state == AIState.CHASING && finished == true)
        {
            Debug.Log("CHASING");
            actions.Clear();
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
            actions.Add(Actions.TILT);
            finished = false;
        }

        if (state == AIState.EVADING)
        {
            actions.Clear();
            actions.Add(Actions.JUMP);
            // add actions for the player to do while evading
        }

        if (state == AIState.IDLE)
        {
            Debug.Log("IDLE");
            actions.Clear();
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
            finished = false;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            jumpTrigger = true;
            speed = -speed;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
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
            grounded = false;
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
        if (t_actions[0] == Actions.MOVE)
        {
            if (!(transform.position.x - enemy.transform.position.x <= 4.0f) ||
                enemy.transform.position.x - transform.position.x >= 4.0f)
            {
                if (enemy.transform.position.x < transform.position.x)
                    transform.position += Vector3.right * speed * Time.deltaTime;
                if (enemy.transform.position.x > transform.position.x)
                    transform.position -= Vector3.right * speed * Time.deltaTime;
            }


        }

        //if (t_actions[0] == Actions.JUMP)
        //{
        //    getPlatforms();

        //    var tempBest = 0.0f;
        //    for (int i = 0; i < allPlatforms.Count; i++)
        //    {
        //        var distance = Vector2.Distance(transform.position, allPlatforms[i].transform.position);

        //        if (distance < tempBest)
        //        {
        //            tempBest = distance;
        //            Debug.Log("ID: " + i.ToString());
        //        }
        //    }
        //}
    }

    void chasingExecution(List<Actions> t_actions)
    {
        //Debug.Log("Im here");
        if (t_actions[0] == Actions.MOVE)
        {
            if (!(transform.position.x - enemy.transform.position.x <= 4.0f) ||
                enemy.transform.position.x - transform.position.x >= 4.0f)
            {
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
            if (grounded)
            {
                //Debug.Log("HELLLOOOOO");
                rb.AddForce(Vector2.up * 6.0f, ForceMode2D.Impulse);
                grounded = false;
                t_actions.RemoveAt(0);
                wee = true;
            }
            else
            {
                t_actions.RemoveAt(0);
            }
            
        }

        if (t_actions[0] == Actions.TILT)
        {
            if ((enemy.transform.position.x > transform.position.x && wee == true) || grounded == true)
            {
                rb.AddForce(Vector2.right * 10.0f, ForceMode2D.Impulse);
                t_actions.RemoveAt(0);
                finished = true;
                wee = false;

            }

            if (enemy.transform.position.x < transform.position.x && wee == true || grounded == true)
            {
                rb.AddForce(Vector2.left * 10.0f, ForceMode2D.Impulse);
                t_actions.RemoveAt(0);
                finished = true;
                wee = false;
            }
        }


        // add shooting etc for chase mode



    }

    void attackingExecution(List<Actions> t_actions)
    {

    }
    
    string syncActions()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            transfer += actions[i].ToString() + ",";
        }

        return transfer;
    }

    void getPlatforms()
    {
        var objects = GameObject.FindGameObjectsWithTag("Platform");
         
        for (int i = 0; i < objects.Length; i++)
        {
            if (allPlatforms.Count == 0)
            {
                for (int k = 0; k < objects.Length; k++)
                {
                    allPlatforms.Add(objects[k]);
                }    
            }

            for (int j = 0; j < allPlatforms.Count;j++)
            {
                if (objects[i].Equals(allPlatforms[j]))
                {
                    break;
                }
                
            }

        }
    }

}
