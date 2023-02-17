using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericPowerup : MonoBehaviour
{
    public GameObject powerUp;
    public Vector3 initialPos;
    public Vector3 newPos;
    public Vector3 testPos;


    private float upperLimit, lowerLimit;

    public bool movingDown, movingUp;

    public bool initialLowering;

    public int startY = 0;

    public GameObject Player;

    //Timer to reset the double jump effect
    private float cooldownTimer;

    // Start is called before the first frame update
    /// <summary>
    /// Set the initial powerup to moving down and its initial pos and new pos are set
    /// Also gets reference to the player
    /// </summary>
    void Start()
    {
        initialLowering = true;
        initialPos = powerUp.transform.position;
        testPos = initialPos;
        movingDown = false;
        movingUp = false;
        startY = 4;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    /// <summary>
    /// Checks if the powerup is outside the upper/ lower limit bounds 
    /// If this is the case then reverse the direction from travelling up to travelling down and vice versa
    /// </summary>
    void Update()
    {
        if(initialLowering == true && testPos.y <= startY)
        {
            initialLowering = false;
            newPos = testPos;
            upperLimit = testPos.y - 0.4f;
            lowerLimit = testPos.y + 0.4f;
            movingDown = true;
        }

        if (movingDown == true && newPos.y < upperLimit)
        {
            movingDown = false;
            movingUp = true;
        }

        if (movingUp == true && newPos.y > lowerLimit)
        {
            movingUp = false;
            movingDown = true;
        }
    }

    /// <summary>
    /// Move the powerup up and down and rotate it so that it looks mystical and less static
    /// </summary>
    private void FixedUpdate()
    {
        if(initialLowering)
        {
            testPos.y = testPos.y - 0.05f;
            powerUp.transform.position = testPos;
        }

        if (movingDown)
        {
            newPos.y = newPos.y - 0.005f;
            powerUp.transform.position = newPos;

        }
        if (movingUp)
        {
            newPos.y = newPos.y + 0.005f;
            powerUp.transform.position = newPos;
        }

        // powerUp.transform.position = newPos;
        powerUp.transform.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
    }

    /// <summary>
    /// Check for the collision witht he player.
    /// If true then the players stats will change based on the powerup gotten
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            powerUp.active = false;
            Debug.Log("OKAYY");

        }
    }
}
