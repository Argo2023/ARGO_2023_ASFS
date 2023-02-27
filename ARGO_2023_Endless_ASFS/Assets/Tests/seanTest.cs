using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class seanTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void seanTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator seanTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator ExplosionStopsPlayingTest()
    {
        GameObject explosion = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ExplosionEffect"));
        explosion.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(5f);

        UnityEngine.Assertions.Assert.IsFalse(explosion.GetComponent<ParticleSystem>().isPlaying);
    }

    [UnityTest]
    public IEnumerator DustPlaysWhenPlayerJumps()
    {
        Vector3 playerPos = new Vector3(0, 0, 0);
        Vector3 platformPos = new Vector3(0, -2, 0);


        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/singlePl"), playerPos, Quaternion.identity);
        GameObject dust = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/DustParticle"));
        GameObject platform = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Platform"), platformPos, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        player.GetComponent<singlePlayerScript>().isGrounded = true;
        player.GetComponent<singlePlayerScript>().OnMoveJump();

        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsFalse(player.GetComponent<singlePlayerScript>().dust.isPlaying);
    }

}
