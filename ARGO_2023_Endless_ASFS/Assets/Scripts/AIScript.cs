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
    List<Actions> actions = new List<Actions>();
    List<GameObject> allPlatforms = new List<GameObject>();
    List<GameObject> allGameObjects = new List<GameObject>();
    AIState state = AIState.NOTHING;

    public string transfer = "";
    public bool jumpTrigger = false;
    public bool grounded = true;
    public bool finished = true;
    public bool wee = false;
    public Rigidbody2D rb;
    float tempBest = float.MaxValue;
    public float speed = 1.0f;
    public int ID = 0;


    Vector2 savedlocalScale;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthScript>().initializePlayer(5, 10); // Initialises the player
        savedlocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        getPlatforms();

        var tempBest = 0.0f;
        for (int i = 0; i < allPlatforms.Count; i++)
        {
            var distance = Vector2.Distance(transform.position, allPlatforms[i].transform.position);

            if (distance < tempBest)
            {
                tempBest = distance;
            }
        }

        choosingBehaviour();

        
        if (rb.velocity.x > 0.001f)
        {
            transform.localScale = new Vector2(savedlocalScale.x, savedlocalScale.y);
        }
        else if (rb.velocity.x < -0.001f)
        {
            transform.localScale = new Vector2(-savedlocalScale.x, savedlocalScale.y);
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
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {

            GameObject bullet = GameObject.FindGameObjectWithTag("DoubleDamage");

            if (bullet.GetComponent<genericPowerup>().isDoubleDamageBullet == true)
            {
                GetComponent<HealthScript>().entityTakesDamage(20);
                bullet.GetComponent<genericPowerup>().isDoubleDamageBullet = false;
            }
            else
            {
                GetComponent<HealthScript>().entityTakesDamage(10);
            }
            Destroy(collision.gameObject);
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
        GameObject myEnemy = GameObject.FindGameObjectWithTag("Player");
        if (t_actions[0] == Actions.MOVE)
        {
            if (!(transform.position.x - myEnemy.transform.position.x <= 8.0f) ||
                myEnemy.transform.position.x - transform.position.x >= 8.0f)
            {
                if (enemy.transform.position.x < transform.position.x)
                    transform.position += Vector3.right * speed * Time.deltaTime;
                if (enemy.transform.position.x > transform.position.x)
                    transform.position -= Vector3.right * speed * Time.deltaTime;
            }
        }

        if (t_actions[0] == Actions.JUMP)
        {
            getPlatforms();
            
            /// Gets the closest platform to the AI the script is running on.
            /// Tries to get to the player, by jumping on the platforms

            for (int i = 0; i < allPlatforms.Count; i++)
            {
                var distance = Vector2.Distance(transform.position, allPlatforms[i].transform.position);

                if (distance < tempBest)
                {
                    tempBest = distance;
                    //Debug.Log("ID: " + i.ToString());
                    ID = i;
                }
            }

            float distanceToPlayer = Vector2.Distance(transform.position, enemy.transform.position);

            //Debug.Log("Distance to Player: " + distanceToPlayer.ToString());
            //Debug.Log("Closest platform: " + tempBest.ToString());

            /// If the player is on the ground, it looks if the player is closer to the AI or is the
            /// platform closer to the AI, which will decide if the AI jumps on the platform.
            /// It runs a coroutine that after 0.2 of a second pushes the AI in a direction to
            /// Mimic player movement trying to climb a platform
            if (grounded)
            {
                if (tempBest < distanceToPlayer)
                {
                    if (transform.position.x - allPlatforms[ID].transform.position.x < 0)
                    {
                        grounded = false;
                        rb.AddForce(Vector2.up * 5.0f, ForceMode2D.Impulse);

                        StartCoroutine(platformJumpRight());
                    }
                    else
                    {
                        grounded = false;
                        rb.AddForce(Vector2.up * 5.0f, ForceMode2D.Impulse);

                        StartCoroutine(platformJumpLeft());
                    }
                }
            }
        }
    }

    IEnumerator platformJumpRight()
    {
        yield return new WaitForSeconds(0.2f);
        rb.AddForce(Vector2.right * 2.0f, ForceMode2D.Impulse);   
    }

    IEnumerator platformJumpLeft()
    {
        yield return new WaitForSeconds(0.2f);
        rb.AddForce(Vector2.left * 2.0f, ForceMode2D.Impulse);
    }

    void chasingExecution(List<Actions> t_actions)
    {
        GameObject myEnemy = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(myEnemy.transform.position);
        if (t_actions[0] == Actions.MOVE)
        {
            if (!(transform.position.x - myEnemy.transform.position.x <= 8.0f) ||
                myEnemy.transform.position.x - transform.position.x >= 8.0f)
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

    /// <summary>
    /// Method for finding all of the platforms that are currently spawned in the scene.
    /// Currently does not handle deleting from the list, when new platforms are in, and old ones are despawned
    /// </summary>

    GameObject[] getPlatforms()
    {
        checkForDeadPlatforms();

        bool maybeNotIn = false;
        var objects = GameObject.FindGameObjectsWithTag("Platform");
         
        if (allPlatforms.Count == 0)
        {
            for(int i = 0; i < objects.Length; i++)
            {
                allPlatforms.Add(objects[i]);
            }
        }

        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = 0; j < allPlatforms.Count;j++)
            {
                maybeNotIn = false;
                if (objects[i].Equals(allPlatforms[j]))
                {
                    maybeNotIn = true;
                    break;
                }
            }

            if (maybeNotIn == false)
            {
                allPlatforms.Add(objects[i]);
            }
        }

        return objects;
    }

    void checkForDeadPlatforms()
    {
        for (int i = 0; i < allPlatforms.Count; i++)
        {
            if (allPlatforms[i] == null)
            {
                allPlatforms.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Returns a value that will be used in decision making for the AI
    /// Gathers distances from all of the relevant GameObjects and decides on danger of each Entity
    /// The lower the weight, the higher the risk AI is currently in
    /// </summary>
    /// <returns></returns>
    float evaluateDistance()
    {
        allGameObjects.Clear();


        int IDOfEntity = 0;
        var players = GameObject.FindGameObjectsWithTag("Player");
        var platforms = getPlatforms();
        var otherAI = GameObject.FindGameObjectsWithTag("AI");


        fillListWithPlayers(players);
        fillListWithPlatforms(platforms);
        fillListWithAI(otherAI);

        int numberOfEntities = players.Length + platforms.Length + otherAI.Length - 1;

        float closestValue = float.MaxValue;

        for (int i = 0; i < numberOfEntities; i++)
        {
            float distance = Vector2.Distance(transform.position, allGameObjects[i].transform.position);

            if (distance < closestValue)
            {
                closestValue = distance;
                IDOfEntity = i;
                //Debug.Log("Closest Entity ID: " + IDOfEntity.ToString());
            }
        }

        if (allGameObjects[IDOfEntity].tag == "Platform")
        {
            return closestValue * 50;
        }

        if (allGameObjects[IDOfEntity].tag == "Player")
        {
            return closestValue * 2;
        }

        if (allGameObjects[IDOfEntity].tag == "AI")
        {
            return closestValue * 10;
        }

        return 0.0f;     
    }

    void fillListWithPlayers(GameObject[] t_players)
    {
        for (int i = 0; i < t_players.Length; i++)
        {
            allGameObjects.Add(t_players[i]);
        }
    }

    void fillListWithPlatforms(GameObject[] t_platforms)
    {
        for (int i = 0; i < t_platforms.Length; i++)
        {
            allGameObjects.Add(t_platforms[i]);
        }
    }

    void fillListWithAI(GameObject[] t_AI)
    {
        for (int i = 0; i < t_AI.Length; i++)
        {
            if (t_AI[i] == this.gameObject)
            {

            }
            else
            {
                allGameObjects.Add(t_AI[i]);
            }
            
        }
    }

    ///Takes the AI health and uses it in deciding what Aciton should the AI Take
    float evaluateHealth()
    { 
        return GetComponent<HealthScript>().baseHealth; 
    }

    /// <summary>
    /// Evaluates in how big of a risk AI is in. If it is really close to the Entity, It will return a low
    /// value, indication that the AI is in HIGH RISK.
    /// </summary>
    /// <returns></returns>
    float evaluateShooting()
    {
        float closestValue = float.MaxValue;

        for (int i = 0; i < allGameObjects.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, allGameObjects[i].transform.position);

            if (distance < closestValue)
            {
                closestValue = distance;
            }
        }

        if (closestValue > 0 && closestValue < 2.0f)
        {
            return closestValue / 100;
        }

        if (closestValue >= 2.0f && closestValue < 10.0f)
        {
            return closestValue * 2;
        }

        if (closestValue > 10)
        {
            return closestValue * 20;
        }

        return 0.0f;
    }

    /// <summary>
    /// Based on the results from the evaluations, this will use a neural network to decide what decision
    /// it should make.
    /// </summary>
    void choosingBehaviour()
    {
        float weight = 0.0f;
        
        weight = evaluateDistance() + evaluateHealth() + evaluateShooting();
        
        Debug.Log("Current weight: " + weight.ToString());

        if (weight < 25)
        {
            actions.Clear();
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
            evadingExecution(actions);
        }


        if (weight >= 25)
        {
            actions.Clear();
            actions.Add(Actions.MOVE);
            actions.Add(Actions.JUMP);
            actions.Add(Actions.TILT);
            chasingExecution(actions);
        }


        allGameObjects.Clear();
    }

    
}
