using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter2D() //When something passer through lose collider
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
