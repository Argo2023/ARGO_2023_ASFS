using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    float randNum = 0.0f;
    float offScreen = 16.0f;
    Vector2 offScreenPos;
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
}
