using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLoop : MonoBehaviour
{

    [Header("Objects To Spawn")]
    public GameObject Platform;
    public GameObject Enemy;
    public GameObject Obstacle;
    public GameObject Tumble;

    [Header("Properties")]
    public int randomSpawnNum;
    public int randomSpawnTumble;
    public int randomPlatformNum;
    private Vector2 offScreen;
    private Vector2 SecondPlatformInRow;
    private Vector2 ThirdPlatformInRow;
    private Vector2 Third2PlatformInRow;
    private Vector2 offScreenTumble;


    public int chanceToSpawnCactus;


    public bool allowSpawn = false;
    public bool allowSpawnTwo = false;

    [Header("floor Script for speed")]
    public scroll floor;

    // Start is called before the first frame update
    void Start()
    {
        allowSpawn = true;
        allowSpawnTwo = true;
        offScreen = new Vector2(20.0f, -1.3f);
        offScreenTumble = new Vector2(18.1f, -4.49f);
        SecondPlatformInRow = new Vector2(20.0f, 0.0f);
        ThirdPlatformInRow = new Vector2(20.0f, 1.5f);
        Third2PlatformInRow = new Vector2(20.0f, -1.0f);


        floor = FindObjectOfType<scroll>();

    }

    // Update is called once per frame
    void Update()
    {
        randomSpawnNum = Random.Range(0, 5);
        randomSpawnTumble = Random.Range(0, 40);

        if (allowSpawn == true && randomSpawnNum == 3)
        {
            StartCoroutine(SpawnObjects());
        }
        if (allowSpawnTwo == true && randomSpawnTumble == 5)
        {
            StartCoroutine(SpawnTumble());
        }
    }


    IEnumerator SpawnTumble()
    { 
        allowSpawnTwo = false;
        yield return new WaitForSeconds(10.0f);

        GameObject tumbleweed = Instantiate(Tumble, offScreenTumble, Quaternion.identity);
        allowSpawnTwo = true;

    }



    IEnumerator SpawnObjects()
    {   allowSpawn = false;
        yield return new WaitForSeconds(3.0f);
        Debug.Log("spawn");

       // if(randomSpawnNum ==3)
       // {
            if (floor.speed > 0.00000f && floor.speed < 0.000600f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
            if (chanceToSpawnCactus == 5)
            {
                Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
            }
                yield return new WaitForSeconds(8.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                 Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(8.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;
            }




            else if (floor.speed > 0.00600f && floor.speed < 0.01000f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                     Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                      GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(5.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(5.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }


            else if (floor.speed > 0.01000f && floor.speed < 0.01500f) 
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                    Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                     GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(3.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(3.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }



            else if (floor.speed > 0.01500f && floor.speed < 0.02000f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                    Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                      GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(2.5f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(2.5f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }




            else if (floor.speed > 0.02000f && floor.speed < 0.02500f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                    Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                      GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(2.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(2.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }



            else if (floor.speed > 0.02500f && floor.speed < 0.03300f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                   Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                      GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(1.5f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(1.5f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }


            else if (floor.speed > 0.03300f && floor.speed < 0.04500f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                    Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                     GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(1.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(1.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                     chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }



            else if (floor.speed > 0.04500f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                    Vector2 pos = new Vector2(offScreen.x, offScreen.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                }
                yield return new WaitForSeconds(0.8f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                chanceToSpawnCactus = Random.Range(0, 8);
                if (chanceToSpawnCactus == 5)
                {
                          Vector2 pos = new Vector2(SecondPlatformInRow.x, SecondPlatformInRow.y + 1.1f);
                       GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                 }
                yield return new WaitForSeconds(0.8f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                     chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                        Vector2 pos = new Vector2(ThirdPlatformInRow.x, ThirdPlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                    chanceToSpawnCactus = Random.Range(0, 8);
                    if (chanceToSpawnCactus == 5)
                    {
                         Vector2 pos = new Vector2(Third2PlatformInRow.x, Third2PlatformInRow.y + 1.1f);
                        GameObject cactusss = Instantiate(Obstacle, pos, Quaternion.identity);
                    }
                }
                allowSpawn = true;

            }
        allowSpawn = true;

        // }
    }
}
