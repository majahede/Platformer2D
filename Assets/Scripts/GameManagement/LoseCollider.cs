using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    /**
     * Called when another objects enters a trigger collider attached to this object.
     */
    void OnTriggerEnter2D()
    {
        Application.Quit();
    }
}
