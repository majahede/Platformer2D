using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
 /*   [UnityTest]
    public IEnumerator MoveRight()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        GameObject playerGameObject = new GameObject( name:"Player");
        PlayerMovement player = playerGameObject.AddComponent<PlayerMovement>();
        var rb = playerGameObject.AddComponent<Rigidbody2D>();
        player.PlayerInput = Substitute.For<IPlayerInput>();
        player.PlayerInput.Horizontal.Returns( returnThis: 1f);

        yield return new WaitForSeconds(1f);

        Assert.IsTrue( condition: player.transform.position.z > 0f);

    }*/
}
