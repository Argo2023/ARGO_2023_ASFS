using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    float randNum = 0.0f;
    float randNum2 = 0.0f;
    float offScreen = 16.0f;
    Vector2 offScreenPos;
    Vector2 aboveScreenPos;
    public singlePlayerScript player;
    public GameObject Platform;
    public GameObject Wall;
    public GameObject Enemy;
    public GameObject Powerup;
    public GameObject AlcoholPowerup;
    public GameObject DynamitePowerup;
    public GameObject DoubleDamageBullet;

    public int platformSpawnNum = 0;
    public int wallSpawnNum = 0;
    public int enemySpawnNum = 0;
    public int powerupSpawnNum = 0;
    public int doubleBullet = 0;

    bool spawnedOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPlatform();
        offScreenPos = new Vector2(offScreen, -4.5f);
        aboveScreenPos = new Vector2(0, 9);
    }

    private void Update()
    {
        if(player.playerAlive == false)
        {
            Debug.Log("1111111");
            restartGame();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        platformSpawnNum++;
        wallSpawnNum++;
        enemySpawnNum++;
        powerupSpawnNum++;
        doubleBullet++;


        if (platformSpawnNum >= 200)
        {
            platformSpawnNum = 0;
            spawnPlatform();
        }

        if (wallSpawnNum >= 90)
        {
            wallSpawnNum = 0;
            spawnWall();
        }

        if (enemySpawnNum == 125)
        {
            //enemySpawnNum = 0;
            spawnEnemy();          
        }

        if(powerupSpawnNum >= 300)
        {
            powerupSpawnNum = 0;
            spawnPowerup();
            spawnAlcohol();
        }

        if (doubleBullet >= 500)
        {
            doubleBullet = 0;
            spawnDynamite();
            spawnBullet();
        }

    }


    void spawnPlatform()
    {
        // -3 to 5 is the amount of leeway for Y value
        randNum = Random.Range(-3, 5);
        Vector3 pos = new Vector3(offScreen, randNum, 0);

        Instantiate(Platform, pos, Quaternion.identity);
    }

    void spawnWall()
    {
        //Instantiate(Wall, offScreenPos, Quaternion.identity);
    }

    void spawnEnemy()
    {
        Instantiate(Enemy, offScreenPos, Quaternion.identity);
    }
    /// <summary>
    /// Instantiates the Alcohol Powerup on a random position above the screen
    /// </summary>
    void spawnAlcohol()
    {
        if (!spawnedOnce)
        {
            spawnedOnce = true;
            randNum2 = Random.Range(-6.5f, 6.5f);
            Vector3 pos2 = new Vector3(randNum2, aboveScreenPos.y, 0);
            Instantiate(AlcoholPowerup, pos2, Quaternion.identity);
        }
    }
    /// <summary>
    /// Instatiates the Dynamite Powerup
    /// </summary>
    void spawnDynamite()
    {
        randNum2 = Random.Range(-6.5f, 6.5f);
        Vector3 pos2 = new Vector3(randNum2, aboveScreenPos.y, 0);
        Instantiate(DynamitePowerup, pos2, Quaternion.identity);
    }

    void spawnBullet()
    {
        randNum2 = Random.Range(-6.5f, 6.5f);
        Vector3 pos2 = new Vector3(randNum2, aboveScreenPos.y, 0);
        Instantiate(DoubleDamageBullet, pos2, Quaternion.identity);
    }
    /// <summary>
    /// Instantiates the health powerup
    /// </summary>
    void spawnPowerup()
    {
        randNum2 = Random.Range(-6.5f, 6.5f);
        Vector3 pos2 = new Vector3(randNum2, aboveScreenPos.y, 0);
        Instantiate(Powerup, pos2, Quaternion.identity);
    }

    void restartGame()
    {
        Debug.Log("Game Restarted");

        player.playerAlive = true;
        player.transform.position = new Vector3(-9.0f, -1.0f, 0.0f);

        platformSpawnNum = 0;
        wallSpawnNum = 0;
        enemySpawnNum = 0;

        var platforms = GameObject.FindGameObjectsWithTag("Platform"); // change this to ground for a differnt game lmao // keep as platform for normal game.
        var walls = GameObject.FindGameObjectsWithTag("wall"); 
        var enemies = GameObject.FindGameObjectsWithTag("AI");
        
        
        foreach (var platform in platforms)
        {
            Destroy(platform);
        }

        foreach (var wall in walls) 
        { 
            Destroy(wall); 
        }


        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
