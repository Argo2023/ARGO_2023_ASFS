using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLoop : MonoBehaviour
{

    [Header("Objects To Spawn")]
    public GameObject Platform;
    public GameObject Enemy;
    public GameObject Obstacle;

    [Header("Properties")]
    public int randomSpawnNum;
    public int randomPlatformNum;
    private Vector2 offScreen;
    private Vector2 SecondPlatformInRow;
    private Vector2 ThirdPlatformInRow;
    private Vector2 Third2PlatformInRow;


    public bool allowSpawn = false;

    [Header("floor Script for speed")]
    public scroll floor;

    // Start is called before the first frame update
    void Start()
    {
        allowSpawn = true;
        offScreen = new Vector2(20.0f, -1.3f);
        SecondPlatformInRow = new Vector2(20.0f, 0.0f);
        ThirdPlatformInRow = new Vector2(20.0f, 1.5f);
        Third2PlatformInRow = new Vector2(20.0f, -1.0f);


        floor = FindObjectOfType<scroll>();

    }

    // Update is called once per frame
    void Update()
    {
        randomSpawnNum = Random.Range(0, 5);
     

        if (allowSpawn == true && randomSpawnNum == 3)
        {
            StartCoroutine(SpawnObjects());
        }
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
                yield return new WaitForSeconds(8.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(8.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.00600f && floor.speed < 0.01000f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(5.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(5.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.01000f && floor.speed < 0.01500f) 
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(3.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(3.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.01500f && floor.speed < 0.02000f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(2.5f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(2.5f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.02000f && floor.speed < 0.02500f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(2.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(2.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.02500f && floor.speed < 0.03300f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.03300f && floor.speed < 0.04500f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(1.0f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
            else if (floor.speed > 0.04500f)
            {
                GameObject platforms = Instantiate(Platform, offScreen, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);
                GameObject platformsTwo = Instantiate(Platform, SecondPlatformInRow, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);

                randomPlatformNum = Random.Range(0, 2);
                if (randomPlatformNum == 0)
                {
                    GameObject platformsThree = Instantiate(Platform, ThirdPlatformInRow, Quaternion.identity);
                }
                if (randomPlatformNum == 1)
                {
                    GameObject platformsThree = Instantiate(Platform, Third2PlatformInRow, Quaternion.identity);
                }
                allowSpawn = true;

            }
        allowSpawn = true;

        // }
    }
}
