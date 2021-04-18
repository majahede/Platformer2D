using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

[SerializeField] Text pickupCount;
[SerializeField] int pickups = 0;

  void start() {
    pickupCount.text = pickups.ToString();
  }

   private void OnTriggerEnter2D(Collider2D collision) {
     Destroy(gameObject);
   }

   public void AddPoint() {
      pickups += 1;
      pickupCount.text = pickups.ToString();
   }
}

  

