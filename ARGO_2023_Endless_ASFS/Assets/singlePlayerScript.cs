using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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

    [SerializeField] private float cooldown = 5;
    

    /// <summary>
    /// On awake it checks if the player has an instance allready.
    /// if this is the case then the instance gameobject is removed.
    /// This ensures that the player is a singleton and just one exists at a time.
    /// </summary>
    void Awake()
    {
       
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
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            playerAlive = false;
            Debug.Log("Do something else here");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            playerAlive = false;
            Destroy(collision.gameObject);
          
        }
    }

}

