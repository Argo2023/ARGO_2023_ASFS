using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SasaTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SasaTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SasaTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestDrunkMode()
    {
        GameObject liquor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/liquor"));
        Camera cam = MonoBehaviour.Instantiate(Resources.Load<Camera>("Prefabs/Main Camera"));
        Vector3 camPos = cam.transform.localPosition;

        liquor.gameObject.GetComponent<genericPowerup>().StartCoroutine("moveCamera");
        yield return new WaitForSeconds(0.1f);

        Assert.AreNotEqual(camPos, cam.transform.localPosition);
    }

    [UnityTest]
    public IEnumerator ExplosionTest()
    {
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/singlePl"));
        GameObject dynamite = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/dynamite"));

        player.transform.position = new Vector3(1.0f, 1.0f, 0.0f);
        dynamite.transform.position = new Vector3(1.0f, 1.0f, 0.0f);

        dynamite.GetComponent<genericPowerup>().StartCoroutine("dynamiteExplosion");

        Assert.True(dynamite.GetComponent<genericPowerup>().dynamiteExploded);
        yield return new WaitForSeconds(0.1f);

        
    }
}
