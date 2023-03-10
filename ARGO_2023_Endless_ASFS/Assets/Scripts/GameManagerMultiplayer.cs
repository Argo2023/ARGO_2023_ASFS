using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class GameManagerMultiplayer : NetworkBehaviour
{
    [Header("Positions & Objectss")]
    float randNum = 0.0f;
    float offScreen = 16.0f;
    Vector2 offScreenPos;
    public playerScript multiPlayer;
    public List<GameObject> multiplayerS;
    public GameObject Platform;
    public GameObject Wall;
    public GameObject Enemy;

    public float platformSpawnTimerFinal = 3;
    public float platformSpawnTimer = 0;
    public int wallSpawnNum = 0;
    public int enemySpawnNum = 0;
    public Text winText;
    public Text loseText;

    [Header("Multiplayer Vars")]
    [SyncVar]
    public Vector3 syncPosition;
 
    /// <summary>
    /// calls SpawnPlatform, sets up an off screen pos
    /// Pulls in the playerScript
    /// </summary>
    void Start()
    {
        if (!isServer)
        {
            return;
        }

        spawnPlatform();

        offScreenPos = new Vector2(offScreen, 3.5f);

        multiPlayer = FindObjectOfType<playerScript>();
        multiplayerS.Add(GameObject.FindGameObjectWithTag("Player"));

    }
    
    void Update()
    {
        if (!isServer)
        {
            return;
        }

        platformSpawnTimer += Time.deltaTime;

        if (platformSpawnTimer >= platformSpawnTimerFinal)
        {
            platformSpawnTimer = 0;
            spawnPlatform();
        }

        //if (wallSpawnNum >= 90)
        //{
        //    wallSpawnNum = 0;
        //    spawnWall();
        //}

        //for(int i = 0; i < multiplayerS.Count; i++)
        //{
        //    if(multiplayerS[i].gameObject.GetComponent<playerScript>().alive == false)
        //    {
        //        multiplayerS[i].gameObject.GetComponent<playerScript>().loseText.enabled = true;
        //        Debug.Log("Player died display lose text");
        //    }
        //}


        //NetworkManager nm = FindObjectOfType<NetworkManager>();
        //Debug.Log(nm.networkAddress.ToString());
        //Debug.Log(nm.numPlayers.ToString());
    }

    /// <summary>
    /// spawn a platform on a random Y value at offscreenPos
    /// </summary>
    [Server]
    void spawnPlatform()
    {
  
        // -3 to 5 is the amount of leeway for Y value
        randNum = Random.Range(-3, 5);
        Vector3 pos = new Vector3(offScreen, randNum, 0);

        GameObject smallPlatform = Instantiate(Platform, pos, Quaternion.identity);

        NetworkServer.Spawn(smallPlatform);
    }

   // [Server]
    //void spawnWall()
    //{
    //    Instantiate(Wall, offScreenPos, Quaternion.identity);
    //    NetworkServer.Spawn(Wall);
    //}

   
    /// <summary>
    /// in order to restart the game, various things need to be reset 
    /// All platforms walls and enemies need to be destroyed
    /// </summary>
    void restartGame()
    {
        Debug.Log("Game Restarted");

        multiPlayer.isPlayerAlive = true;

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
