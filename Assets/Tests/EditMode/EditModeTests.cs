using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTests
{
    // Resets environment.
    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void EnemyTakes30Damage()
    {
        var gameObject = new GameObject();
        var enemy = gameObject.AddComponent<Enemy>(); 
        enemy.TakeDamage(30);

        Assert.AreEqual(enemy.GetHealth(), 70);
    }

    [Test]
    public void BasicTest()
    {
        bool isActive = false;

        Assert.AreEqual(false, isActive);
    }

    [Test]
    public void CatchingErrors()
    {
        GameObject gameObject = new GameObject("test");

        Assert.Throws<MissingComponentException>(
            () => gameObject.GetComponent<Rigidbody>().velocity = Vector3.one);
    }
}
