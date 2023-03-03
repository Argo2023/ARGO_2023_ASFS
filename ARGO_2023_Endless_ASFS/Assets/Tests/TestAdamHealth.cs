using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestAdamHealth 
{

    // A Test behaves as an ordinary method
    [Test]
    public void TestAdamHealthSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestAdamHealthWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    public void Setup()
    {
        //GameObject go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/singlePl"));
    }

    [UnityTest]
    public IEnumerator TestHealthBarValue()
    {
        Vector3 playerPos = new Vector3(0, 0, 0);
        GameObject hpBar= MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Health bar 1"));
        float initialValue = hpBar.gameObject.GetComponent<Slider>().value;

        GameObject ai = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Resources AI"), playerPos, Quaternion.identity);
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/resources Player"), playerPos, Quaternion.identity);

        float damageTaken = player.GetComponent<ResourcesSinglePLayer>().currentHealth;

        yield return new WaitForSeconds(0.3f);
      
        Assert.Greater(initialValue, damageTaken);

        
    }


    [UnityTest]
    public IEnumerator checkForDeathMessage()
    {
        Vector3 playerPos = new Vector3(0, 0, 0);
        Healthbar hpBar = MonoBehaviour.Instantiate(Resources.Load<Healthbar>("Prefabs/Health bar 1"));
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/resources Player"), playerPos, Quaternion.identity);
        player.GetComponent<ResourcesSinglePLayer>().currentHealth = 1;
        GameObject ai = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Resources AI"), playerPos, Quaternion.identity);

        yield return new WaitForSeconds(2f);

        Vector3 deathPos = player.gameObject.transform.position;

        Assert.Less(deathPos.x, playerPos.x);

        //Camera cams = MonoBehaviour.Instantiate(Resources.Load<Camera>("Prefabs/Main Camera"));
        //TextMesh deathText1 = MonoBehaviour.Instantiate(Resources.Load<TextMesh>("Prefabs/Death Text"));
        //TextMesh deathText2 = MonoBehaviour.Instantiate(Resources.Load<TextMesh>("Prefabs/Death Text 2"));

        //hpBar.GetComponent<Healthbar>().setMaxHealth(player.GetComponent<singlePlayerScript>().maxHealth);
        //player.GetComponent<singlePlayerScript>().deathText= deathText1;
        //player.GetComponent<singlePlayerScript>().deathTextTwo = deathText2;
        //player.GetComponent<singlePlayerScript>().cam = cams;

        //player.gameObject.GetComponent<singlePlayerScript>().cam.enabled = true;
        //player.gameObject.GetComponent<singlePlayerScript>().currentHealth = 0;


        //Assert.True(player.GetComponent<singlePlayerScript>().cam.enabled == false);
    }

    [UnityTest]
    public IEnumerator checkScore()
    {
        Vector3 playerPos = new Vector3(0, 0, 0);

        gameLoopResources gameMan = MonoBehaviour.Instantiate(Resources.Load<gameLoopResources>("Prefabs/GameLoop Resources"));
        GameObject score = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Score Text"));
        int prevScore = gameLoopResources.score;
        GameObject ai = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/enemy Basic"), playerPos, Quaternion.identity);
        GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/bullet 1"),playerPos, Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
       
        int scoreIncrement = gameLoopResources.score;

        Assert.Less(prevScore, scoreIncrement);

    }
}
