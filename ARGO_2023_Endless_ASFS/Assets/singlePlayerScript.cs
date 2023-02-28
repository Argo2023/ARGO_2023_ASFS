using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class singlePlayerScript : MonoBehaviour
{
    [Header("Player stuff")]

    public Rigidbody2D rb;
    public float jumpForce = 0;
    public int jumpCount = 0;
    public int allowedJumps = 0;
    public float gravityScale = 0;
    public float fallingGravityScale = 0;
    public bool isGrounded = false;
    public float playerSpeed = 5.0f;
    public bool m_FacingRight = true;
    public bool m_FacingLeft = false;
    Vector2 savedlocalScale;
    public bool resetJump = false;

    public bool playerAlive = true;

    public Joystick joystick;

    bool testingOnPC = false; //change to true if you want to test the game using mouse and key :)

    public ParticleSystem dust;
    public static singlePlayerScript instance = null; 

    [SerializeField] private float cooldown = 5;

    [Header("UI Related Vars")]
    public Healthbar healthbar;
    public int maxHealth = 5;
    public int currentHealth;
    public Camera cam;
    public Camera cam2;
    float timer;
    public TextMesh deathText;
    public TextMesh deathTextTwo;


    /// <summary>
    /// On awake it checks if the player has an instance allready.
    /// if this is the case then the instance gameobject is removed.
    /// This ensures that the player is a singleton and just one exists at a time.
    /// </summary>
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sets the variable neccessary for the player by calling the required functions.
    /// Xp bar 
    /// Health bar
    /// Stamina bar
    /// and the level text 
    /// are all set up by calling their various functions
    /// </summary>
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        savedlocalScale = transform.localScale;

        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);

        deathText.gameObject.active = false;
        deathTextTwo.gameObject.active = false;

        cam = Camera.main;
        cam.enabled = true;
        cam2.enabled = false;
        
    }

    // Update is called once per frame
    /// <summary>
    /// On update sets the animations of the player given the way the player is facing/ moving
    /// decresases the players stamina when movements are made
    /// Adds to the players stamina when they are percieved as standing still
    /// Set the players speed back to its default when their stamina is over or equal to 10
    /// Deals with the allowing the player to jump or not and then jumping the player
    /// sets the xpBar and stamina bar
    /// sets up a coroutine for if the player is killed.
    /// Runs said coroutine in the event of that happening
    /// Sets up leveling up for the player based on the XP that they have.
    /// Handles these levelups
    /// </summary>
    void Update()
    {
            ////////////////////////////////////////////////////////////////////////////            <<--------- MOVEMENT
        if(testingOnPC == false)
        {
            var horizontalInput = joystick.Horizontal;
            rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
        }
        else if(testingOnPC == true)
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
        }

        if (rb.velocity.x > 0.001f)
        {
            // animator.SetFloat("speed", Mathf.Abs(playerSpeed));
            transform.localScale = new Vector2(savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = false;
            m_FacingRight = true;
          
        }
        else if (rb.velocity.x < -0.001f)
        {
            //animator.SetFloat("speed", Mathf.Abs(playerSpeed));
            transform.localScale = new Vector2(-savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = true;
            m_FacingRight = false;
           
        }

        if (rb.velocity.x == 0.0f)
        {
            //animator.SetFloat("speed", Mathf.Abs(0));

        }

        ////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////            <<--------- JUMPING


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("isJumping", true);
            jumpCount += 1;
            if (jumpCount == allowedJumps)
            {
                isGrounded = false;
            }
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        } 

        }

        //currently reloading the main game scene again we can change this to do anything we need it to - Adam
        if (isPlayerDead() == true)
        {
            StartCoroutine(Killcam());
        }

        // if(IsVisibleFrom(gameObject.GetComponent<Renderer>(), cam) == false)
        // {
        //     Debug.Log("Player should take damage he is outside the camera view");
        //     TakeDamage(1);
        // }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
    }

    void FixedUpdate()
    {
        if(IsVisibleFrom(gameObject.GetComponent<Renderer>(), cam) == false)
        {
            Debug.Log("Player should take damage he is outside the camera view");
            if(timer <= 0)
            {
                TakeDamage(1);
            }
        }
    }

    IEnumerator Killcam()
    {
        yield return new WaitForSeconds(6.0f);
        Debug.Log("The Player Died - Do our restart scene ");
        SceneManager.LoadScene("SP Adam");
    }

    IEnumerator OutsideZone()
    {
        while (true)
        {
            TakeDamage(1);

            yield return new WaitForSeconds(2.0f);
        }
    }

    public void TakeDamage(int t_damage)
    {
        timer =1;
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);
        if (isPlayerDead())
        {
            //playerAlive = false;
            gameObject.transform.position = new Vector2(20.12f, 4.11f);
            deathText.gameObject.active = true;
            deathTextTwo.gameObject.active = true;
            cam.enabled = false;
            cam2.enabled = true;
        }
    }

    public bool isPlayerDead() // checks if the player is dead
    {
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            //playerAlive = false;
            TakeDamage(1);
        }
    }

    public bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }


    //public void OnMoveLeft()
    //{
    //    transform.position = new Vector3(transform.position.x + playerSpeed, transform.position.y, transform.position.z);
    //}

    //public void OnMoveRight()
    //{
    //    print("aaaaaaaaa");
    //}



    public void OnMoveJump()
    {
        createDust();
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("isJumping", true);
            jumpCount += 1;
            if (jumpCount == allowedJumps)
            {
                isGrounded = false;
            }
        }

    }

    public void createDust()
    {
        dust.Play();
    }

   
}




