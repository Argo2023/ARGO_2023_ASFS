using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericPowerup : MonoBehaviour
{
    public GameObject powerUp;
    Camera cam;
    public Vector3 initialPos;
    public Vector3 newPos;
    public Vector3 testPos;
    Vector3 newCamPos;


    private float upperLimit, lowerLimit;

    public bool movingDown, movingUp;

    public bool initialLowering;
    public bool finished = true;

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
        cam = Camera.main;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    /// <summary>
    /// Checks if the powerup is outside the upper/ lower limit bounds 
    /// If this is the case then reverse the direction from travelling up to travelling down and vice versa
    /// </summary>
    void Update()
    {
        if (powerUp.CompareTag("Alcohol"))
        {
            
        }
        else
        {
            if (initialLowering == true && testPos.y <= startY)
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
    }

    /// <summary>
    /// Move the powerup up and down and rotate it so that it looks mystical and less static
    /// </summary>
    private void FixedUpdate()
    {
        if (powerUp.CompareTag("Alcohol"))
        {
            Debug.Log(cam.transform.position);
        }
        else
        {
            if (initialLowering)
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
    }

    /// <summary>
    /// Check for the collision witht he player.
    /// If true then the players stats will change based on the powerup gotten
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            powerUp.active = false;
            //Debug.Log("OKAYY");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && powerUp.tag == "Alcohol")
        {;
            //Debug.Log("ME HEEEREEEEEEEE");
            powerUp.transform.position = new Vector3(3000.0f, transform.position.y, transform.position.z);
            StartCoroutine(moveCamera());
        }
    }


    IEnumerator moveCamera()
    {
        for(int i = 0; i < 3; i++)
        {
            cam = Camera.main;
            newCamPos = new Vector3(cam.transform.position.x + Random.Range(-4.0f, 4.0f),
                                    cam.transform.position.y + Random.Range(-1.0f, 1.0f),
                                    -10.0f);
            float time = 0;
            Vector3 startPos = cam.transform.localPosition;
            while (time < 5.0f)
            {
                cam.transform.localPosition = Vector3.Lerp(startPos, newCamPos, time / 5.0f);
                time += Time.deltaTime;
                Debug.Log(cam.transform.localPosition);
                yield return null;
            }
            time = 0.0f;
        }
    }
}
