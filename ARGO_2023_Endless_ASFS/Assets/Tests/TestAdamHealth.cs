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
}
