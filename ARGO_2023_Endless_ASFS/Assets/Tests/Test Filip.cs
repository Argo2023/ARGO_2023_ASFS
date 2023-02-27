using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestFilip
{
 

    // A Test behaves as an ordinary method
    [Test]
    public void TestFilipSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestFilipWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlatformSpawnMove()
    {
        GameObject floor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/floor"));
        GameObject platform = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Platform"));
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(4.0f);


        Assert.Less(platform.transform.position.x, 3.74f);
        
    }
}
