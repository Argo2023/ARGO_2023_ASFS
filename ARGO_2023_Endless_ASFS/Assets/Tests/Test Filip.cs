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



    [UnityTest]
    public IEnumerator CactusSpawnMove()
    {
        GameObject floor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/floor"));
        GameObject cactus = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/cactus"));
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(4.0f);


        Assert.Less(cactus.transform.position.x, 3.74f);

    }


    [UnityTest]
    public IEnumerator TumbleSpawnMove()
    {
        GameObject floor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/floor"));
        GameObject Tumble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Tumble"));
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(10.0f);

        Assert.Less(Tumble.transform.position.x, 18.9f);

    }

    [UnityTest]
    public IEnumerator EnemiesSpawnMove()
    {
    
        GameObject floor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/floor"));
        GameObject enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ZeAIFIFI"));
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(4.0f);

        Assert.Less(enemy.transform.position.x, 3.74f);

    }
}
