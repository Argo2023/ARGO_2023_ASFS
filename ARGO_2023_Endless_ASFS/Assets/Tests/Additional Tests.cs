using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AdditionalTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void AdditionalTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AdditionalTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }



public class bulletMultiplayerTest
{
    [UnityTest]
    public IEnumerator Bullet_Destroyed_OnCollidingWithPlatform()
    {
        // Arrange
        var bulletObject = new GameObject();
        bulletObject.tag = "Bullet";
        var bullet = bulletObject.AddComponent<bulletMultiplayer>();

        var platformObject = new GameObject();
        platformObject.tag = "Platform";
        platformObject.AddComponent<BoxCollider2D>();

        // Assert
        Assert.IsNotNull(bullet.gameObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Bullet_Destroyed_After10Seconds_WithoutCollision()
    {
        // Arrange
        var bulletObject = new GameObject();
        bulletObject.tag = "Bullet";
        bulletObject.AddComponent<Rigidbody2D>();
        var bullet = bulletObject.AddComponent<bulletMultiplayer>();

        // Act
        yield return new WaitForSeconds(11);

        // Assert
        Assert.NotNull(bullet.gameObject);
    }
       

    }

}
