using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickup : MonoBehaviour
{

   private void OnTriggerEnter2D(Collider2D collision) {

     FindObjectOfType<GameSession>().AddPoint();
     Destroy(gameObject);
   }

  
}
