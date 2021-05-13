using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MoveRight()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerMovement>();

        player.Run();
        yield return new WaitForSeconds(5f);

       // Assert.AreEqual( expected: new )
    }
}
