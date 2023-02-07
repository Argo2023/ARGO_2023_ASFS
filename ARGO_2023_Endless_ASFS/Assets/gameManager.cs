using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    float randNum = 0.0f;
    float offScreen = 16.0f;
    public GameObject Platform;

    public int testNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPlatform();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        testNum++;
        if(testNum >= 200)
        {
            testNum = 0;
            spawnPlatform();
        }
    }


    void spawnPlatform()
    {
        // -3 to 5 is the amount of leeway for Y value
        randNum = Random.Range(-3, 5);
        Vector3 pos = new Vector3(offScreen, randNum, 0);

        Instantiate(Platform, pos, Quaternion.identity);
    }
}
