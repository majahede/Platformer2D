using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoseCollider : MonoBehaviour
{
    [SerializeField] Player player;
    private void OnTriggerEnter2D(Collider2D collision) //When something passer through lose collider
    {
      player.currentHealth = 0;
       // UnityEditor.EditorApplication.isPlaying = false;
    }

}
