using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
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
        GameObject hpBar= MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Health bar 1"));

        float initialValue = hpBar.gameObject.GetComponent<Slider>().value;
        float damageTaken = hpBar.gameObject.GetComponent<Slider>().value -= 1;
        yield return new WaitForSeconds(0.3f);
      
        Assert.Greater(initialValue, damageTaken);

        
    }


    [UnityTest]
    public IEnumerator checkForDeathMessage()
    {
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/singlePl"));
        Healthbar hpBar = MonoBehaviour.Instantiate(Resources.Load<Healthbar>("Prefabs/Health bar 1"));
        Camera cams = MonoBehaviour.Instantiate(Resources.Load<Camera>("Prefabs/Main Camera"));
        TextMesh deathText1 = MonoBehaviour.Instantiate(Resources.Load<TextMesh>("Prefabs/Death Text"));
        TextMesh deathText2 = MonoBehaviour.Instantiate(Resources.Load<TextMesh>("Prefabs/Death Text 2"));

        hpBar.GetComponent<Healthbar>().setMaxHealth(player.GetComponent<singlePlayerScript>().maxHealth);
        player.GetComponent<singlePlayerScript>().deathText= deathText1;
        player.GetComponent<singlePlayerScript>().deathTextTwo = deathText2;
        player.GetComponent<singlePlayerScript>().cam = cams;

        player.gameObject.GetComponent<singlePlayerScript>().cam.enabled = true;
        player.gameObject.GetComponent<singlePlayerScript>().currentHealth = 0;

        yield return null;

        Assert.True(player.GetComponent<singlePlayerScript>().cam.enabled == false);
    }

    [UnityTest]
    public IEnumerator checkScore()
    {
        gameLoop gameMan = MonoBehaviour.Instantiate(Resources.Load<gameLoop>("Prefabs/gameloop"));
        //GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));

        int prevScore = gameLoop.score;
        gameLoop.score++;
        int scoreIncrement = gameLoop.score;
        yield return new WaitForSeconds(0.1f);

        Assert.Less(prevScore, scoreIncrement);

    }
}
