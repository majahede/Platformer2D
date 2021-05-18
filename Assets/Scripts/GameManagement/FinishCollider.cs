using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    public SceneLoader sceneLoader;

    void OnTriggerEnter2D()
    {
        sceneLoader.LoadMainMenu();
    }
}
