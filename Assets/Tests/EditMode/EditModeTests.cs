using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
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
            const bool IsActive = false;

            Assert.AreEqual(false, IsActive);
        }

        [Test]
        public void CatchingErrors()
        {
            var gameObject = new GameObject("test");

            Assert.Throws<MissingComponentException>(
                () => gameObject.GetComponent<Rigidbody>().velocity = Vector3.one);
        }
    }
}

