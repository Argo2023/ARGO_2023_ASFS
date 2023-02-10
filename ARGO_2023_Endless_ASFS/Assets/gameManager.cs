using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    float randNum = 0.0f;
    float offScreen = 16.0f;
    Vector2 offScreenPos;
    public singlePlayerScript player;
    public GameObject Platform;
    public GameObject Wall;
    public GameObject Enemy;

    public int platformSpawnNum = 0;
    public int wallSpawnNum = 0;
    public int enemySpawnNum = 0;



    // Start is called before the first frame update
    void Start()
    {
        spawnPlatform();
        offScreenPos = new Vector2(offScreen, -5.5f);
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

        if (enemySpawnNum >= 125)
        {
            enemySpawnNum = 0;
            spawnEnemy();
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
        Instantiate(Wall, offScreenPos, Quaternion.identity);
    }

    void spawnEnemy()
    {
        Instantiate(Enemy, offScreenPos, Quaternion.identity);
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
